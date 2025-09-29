using HomeNest.Domain.Entities;

namespace HomeNest.Infrastructure.Repositories.Interfaces;

public interface IUserSessionRepository : IGenericRepository<UserSession>
{
    Task<UserSession?> GetByRefreshTokenAsync(string refreshToken);
    Task<IEnumerable<UserSession>> GetByUserIdAsync(int userId);
    Task RevokeSessionAsync(string refreshToken);
    Task RevokeAllSessionsAsync(int userId);
}
