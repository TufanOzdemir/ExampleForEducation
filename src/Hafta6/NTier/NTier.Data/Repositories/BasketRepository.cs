using NTier.Data.Abstraction;
using NTier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Data.Repositories
{
    internal class BasketRepository(MarketplaceDbContext marketplaceDbContext) : IBasketRepository
    {
        public void Add(Basket basket)
        {
            marketplaceDbContext.Baskets.Add(basket);
        }

        public void ClearBasket(int userId)
        {
            var baskets = marketplaceDbContext.Baskets.Where(b => b.UserId == userId);
            marketplaceDbContext.Baskets.RemoveRange(baskets);
        }
    }
}
