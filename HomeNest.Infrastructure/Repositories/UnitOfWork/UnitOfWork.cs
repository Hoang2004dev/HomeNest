using HomeNest.Domain.Entities;
using HomeNest.Infrastructure.Data;
using HomeNest.Infrastructure.Repositories.Implementations;
using HomeNest.Infrastructure.Repositories.Interfaces;

namespace HomeNest.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly HomeNestDbContext _context;

    public IGenericRepository<User> Users { get; }
    public IGenericRepository<UserSession> UserSessions { get; }
    public IGenericRepository<Product> Products { get; }
    public IGenericRepository<Order> Orders { get; }
    public IGenericRepository<Payment> Payments { get; }
    public IGenericRepository<Voucher> Vouchers { get; }
    public IGenericRepository<Promotion> Promotions { get; }

    public UnitOfWork(HomeNestDbContext context)
    {
        _context = context;
        Users = new GenericRepository<User>(context);
        UserSessions = new GenericRepository<UserSession>(context);
        Products = new GenericRepository<Product>(context);
        Orders = new GenericRepository<Order>(context);
        Payments = new GenericRepository<Payment>(context);
        Vouchers = new GenericRepository<Voucher>(context);
        Promotions = new GenericRepository<Promotion>(context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
