using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repositories;

internal class OrderRepository(MarketplaceDbContext _context) : IOrderRepository
{
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
