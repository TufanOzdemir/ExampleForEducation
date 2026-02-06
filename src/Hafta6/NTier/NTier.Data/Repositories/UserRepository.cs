using Microsoft.EntityFrameworkCore;
using NTier.Data.Abstraction;
using NTier.Data.Entities;

namespace NTier.Data.Repositories
{
    internal class UserRepository(MarketplaceDbContext marketplaceDbContext) : IUserRepository
    {
        public List<User> GetAll()
        {
            return marketplaceDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return marketplaceDbContext.Users
               .AsSplitQuery()
               .Include(u => u.Baskets)
                   .ThenInclude(b => b.Product)
               .Include(u => u.Orders)
                   .ThenInclude(o => o.OrderProducts)
               .FirstOrDefault(c => c.Id == id);
        }
    }
}
