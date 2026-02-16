using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;

namespace BasketService.Infrastructure.Repositories;

internal class OrderRepository(MarketplaceDbContext _context) : IOrderRepository
{
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
