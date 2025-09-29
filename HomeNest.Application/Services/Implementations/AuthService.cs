using AutoMapper;
using HomeNest.Application.DTOs.Auth;
using HomeNest.Application.Services.Interfaces;
using HomeNest.Domain.Entities;
using HomeNest.Infrastructure.Identity;
using HomeNest.Infrastructure.Repositories.Interfaces;
using HomeNest.Infrastructure.Repositories.UnitOfWork;

namespace HomeNest.Application.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly TokenService _tokenService;
    private readonly PasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        IUserSessionRepository userSessionRepository,
        TokenService tokenService,
        PasswordHasher passwordHasher,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _userSessionRepository = userSessionRepository;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _userRepository.EmailExistsAsync(request.Email))
            throw new Exception("Email already registered.");

        var user = _mapper.Map<User>(request);
        user.PasswordHash = _passwordHasher.HashPassword(request.Password);

        await _userRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return await GenerateTokensAsync(user, "Register", "0.0.0.0");
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials.");

        return await GenerateTokensAsync(user, request.DeviceInfo, request.IpAddress);
    }

    public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        if (principal == null) throw new Exception("Invalid access token.");

        var userId = int.Parse(principal.FindFirst("sub")!.Value);

        var session = await _userSessionRepository.GetByRefreshTokenAsync(request.RefreshToken);
        if (session == null || session.ExpiryDate < DateTime.UtcNow || session.IsRevoked == true)
            throw new Exception("Invalid refresh token.");

        var user = await _userRepository.GetByIdAsync(userId) ?? throw new Exception("User not found.");

        session.IsRevoked = true;
        await _unitOfWork.CompleteAsync();

        return await GenerateTokensAsync(user, session.DeviceInfo ?? "Unknown", session.IpAddress ?? "0.0.0.0");
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await _userSessionRepository.RevokeSessionAsync(refreshToken);
        await _unitOfWork.CompleteAsync();
    }

    public async Task LogoutAllAsync(int userId)
    {
        await _userSessionRepository.RevokeAllSessionsAsync(userId);
        await _unitOfWork.CompleteAsync();
    }

    private async Task<AuthResponse> GenerateTokensAsync(User user, string deviceInfo, string ipAddress)
    {
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var session = _mapper.Map<UserSession>((user.Id, refreshToken, deviceInfo, ipAddress));
        await _userSessionRepository.AddAsync(session);
        await _unitOfWork.CompleteAsync();

        var response = _mapper.Map<AuthResponse>(user);
        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;
        response.ExpiryDate = session.ExpiryDate;

        return response;
    }
}
