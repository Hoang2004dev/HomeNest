namespace HomeNest.Application.DTOs.Auth;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DeviceInfo { get; set; } = "Unknown";
    public string IpAddress { get; set; } = "0.0.0.0";
}
