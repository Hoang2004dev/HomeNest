using HomeNest.Domain.Entities;
using HomeNest.Infrastructure.Data;
using HomeNest.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeNest.Infrastructure.Repositories.Implementations;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly HomeNestDbContext _context;

    public UserRepository(HomeNestDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
