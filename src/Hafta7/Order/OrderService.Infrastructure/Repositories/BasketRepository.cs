using OrderService.Application.Interfaces.Repository;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories;

internal class BasketRepository(OrderDbContext context) : IBasketRepository
{
    public void ClearBasket(int userId)
    {
        var baskets = context.Baskets.Where(b => b.UserId == userId).ToList();
        context.Baskets.RemoveRange(baskets);
    }
}
