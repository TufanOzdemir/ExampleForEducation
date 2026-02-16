using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories;

internal class OrderRepository(MarketplaceDbContext _context) : IOrderRepository
{
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
