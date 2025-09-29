using HomeNest.Domain.Entities;
using HomeNest.Infrastructure.Data;
using HomeNest.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeNest.Infrastructure.Repositories.Implementations;

public class UserSessionRepository : GenericRepository<UserSession>, IUserSessionRepository
{
    private readonly HomeNestDbContext _context;

    public UserSessionRepository(HomeNestDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserSession?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.UserSessions
            .FirstOrDefaultAsync(s => s.RefreshToken == refreshToken && s.IsRevoked == false);
    }

    public async Task<IEnumerable<UserSession>> GetByUserIdAsync(int userId)
    {
        return await _context.UserSessions
            .Where(s => s.UserId == userId && s.IsRevoked == false)
            .ToListAsync();
    }

    public async Task RevokeSessionAsync(string refreshToken)
    {
        var session = await _context.UserSessions.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
        if (session != null)
        {
            session.IsRevoked = true;
            _context.UserSessions.Update(session);
        }
    }

    public async Task RevokeAllSessionsAsync(int userId)
    {
        var sessions = await _context.UserSessions.Where(s => s.UserId == userId).ToListAsync();
        foreach (var s in sessions)
        {
            s.IsRevoked = true;
        }
        _context.UserSessions.UpdateRange(sessions);
    }
}
