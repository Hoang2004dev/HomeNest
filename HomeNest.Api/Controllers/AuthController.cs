using HomeNest.Application.DTOs.Auth;
using HomeNest.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeNest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Đăng ký tài khoản mới
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Đăng nhập
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Làm mới Access Token bằng Refresh Token
    /// </summary>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var result = await _authService.RefreshTokenAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Đăng xuất 1 session (invalidate refresh token)
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] string refreshToken)
    {
        await _authService.LogoutAsync(refreshToken);
        return Ok(new { message = "Logged out successfully" });
    }

    /// <summary>
    /// Đăng xuất tất cả session của user
    /// </summary>
    [HttpPost("logout-all/{userId}")]
    public async Task<IActionResult> LogoutAll(int userId)
    {
        await _authService.LogoutAllAsync(userId);
        return Ok(new { message = "All sessions revoked successfully" });
    }
}
