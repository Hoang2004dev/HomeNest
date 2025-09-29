using AutoMapper;
using HomeNest.Application.DTOs.Auth;
using HomeNest.Domain.Entities;
using HomeNest.Domain.Enums;

namespace HomeNest.Application.Mappings;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        // DTO -> User
        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(_ => UserRole.Customer))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => UserStatus.Active))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

        // User -> AuthResponse (basic)
        CreateMap<User, AuthResponse>()
            .ForMember(dest => dest.AccessToken, opt => opt.Ignore())
            .ForMember(dest => dest.RefreshToken, opt => opt.Ignore())
            .ForMember(dest => dest.ExpiryDate, opt => opt.Ignore());

        // DTO -> UserSession
        CreateMap<(int userId, string refreshToken, string deviceInfo, string ipAddress), UserSession>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userId))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.refreshToken))
            .ForMember(dest => dest.DeviceInfo, opt => opt.MapFrom(src => src.deviceInfo))
            .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.ipAddress))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(_ => DateTime.UtcNow.AddDays(7)))
            .ForMember(dest => dest.IsRevoked, opt => opt.MapFrom(_ => false));
    }
}
