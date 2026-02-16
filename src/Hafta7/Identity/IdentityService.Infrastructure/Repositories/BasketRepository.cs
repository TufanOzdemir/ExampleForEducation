using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;

namespace IdentityService.Infrastructure.Repositories;

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
