using HomeNest.Infrastructure.Data;
using HomeNest.Infrastructure.Identity;

namespace HomeNest.Infrastructure.Data.Seeds
{
    public static class SeedData
    {
        public static async Task InitializeAsync(HomeNestDbContext context, PasswordHasher hasher)
        {
            if (!context.Users.Any())
            {
                var users = UserSeed.GetUsers(hasher);
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }
        }
    }
}