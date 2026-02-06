using NTier.Data.Abstraction;
using NTier.Data.Entities;

namespace NTier.Data.Repositories
{
    internal class OrderRepository(MarketplaceDbContext marketplaceDbContext) : IOrderRepository
    {
        public void Add(Order order)
        {
            marketplaceDbContext.Orders.Add(order);
        }
    }
}
