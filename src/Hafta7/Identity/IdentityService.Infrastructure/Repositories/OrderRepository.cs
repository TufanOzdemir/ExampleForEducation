using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;

namespace IdentityService.Infrastructure.Repositories;

internal class OrderRepository(MarketplaceDbContext _context) : IOrderRepository
{
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
