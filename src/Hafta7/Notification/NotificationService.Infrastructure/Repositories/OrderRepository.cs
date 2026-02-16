using NotificationService.Application.Interfaces.Repository;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Repositories;

internal class OrderRepository(MarketplaceDbContext _context) : IOrderRepository
{
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
