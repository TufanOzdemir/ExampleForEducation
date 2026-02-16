using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;

namespace BasketService.Infrastructure.Repositories;

internal class BasketRepository(MarketplaceDbContext _context) : IBasketRepository
{
    public void Add(Basket basket)
    {
        _context.Baskets.Add(basket);
    }

    public void ClearBasket(int userId)
    {
        var baskets = _context.Baskets.Where(b => b.UserId == userId).ToList();
        _context.Baskets.RemoveRange(baskets);
    }
}
