using HomeNest.Infrastructure.Data;
using HomeNest.Infrastructure.Identity;
using HomeNest.Infrastructure.Repositories.Implementations;
using HomeNest.Infrastructure.Repositories.Interfaces;
using HomeNest.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeNest.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<HomeNestDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Bind JwtSettings
        services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

        // Add Identity services
        services.AddScoped<TokenService>();
        services.AddScoped<PasswordHasher>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserSessionRepository, UserSessionRepository>();

        return services;
    }
}
