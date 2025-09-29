using HomeNest.Domain.Entities;
using HomeNest.Domain.Enums;
using HomeNest.Infrastructure.Identity;

namespace HomeNest.Infrastructure.Data.Seeds;

public static class UserSeed
{
    public static List<User> GetUsers(PasswordHasher hasher)
    {
        // Fix UTC → Unspecified để match PostgreSQL "timestamp without time zone"
        var now = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

        return new List<User>
        {
            new User
            {
                FullName = "Admin User",
                Email = "admin@gmail.com",
                PasswordHash = hasher.HashPassword("Admin@123"),
                Role = UserRole.Admin,
                Status = UserStatus.Active,
                CreatedAt = now,
                UpdatedAt = now
            },
            new User
            {
                FullName = "Test Customer",
                Email = "customer@gmail.com",
                PasswordHash = hasher.HashPassword("Customer@123"),
                Role = UserRole.Customer,
                Status = UserStatus.Active,
                CreatedAt = now,
                UpdatedAt = now
            }
        };
    }
}
