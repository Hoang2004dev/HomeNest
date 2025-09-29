using System;
using System.Collections.Generic;

namespace HomeNest.Domain.Entities;

public partial class UserSession
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? DeviceInfo { get; set; }

    public string? IpAddress { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool? IsRevoked { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
