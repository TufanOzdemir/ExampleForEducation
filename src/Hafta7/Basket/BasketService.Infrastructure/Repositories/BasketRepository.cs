using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;

namespace BasketService.Infrastructure.Repositories;

internal class BasketRepository(BasketDbContext context) : IBasketRepository
{
    public void Add(Basket basket)
    {
        context.Baskets.Add(basket);
    }

    public void ClearBasket(int userId)
    {
        var baskets = context.Baskets.Where(b => b.UserId == userId).ToList();
        context.Baskets.RemoveRange(baskets);
    }
}
