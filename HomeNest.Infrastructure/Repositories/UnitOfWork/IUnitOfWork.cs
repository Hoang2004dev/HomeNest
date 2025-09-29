using HomeNest.Domain.Entities;
using HomeNest.Infrastructure.Repositories.Interfaces;

namespace HomeNest.Infrastructure.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> Users { get; }
    IGenericRepository<Product> Products { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<Payment> Payments { get; }
    IGenericRepository<Voucher> Vouchers { get; }
    IGenericRepository<Promotion> Promotions { get; }

    Task<int> CompleteAsync();
}
