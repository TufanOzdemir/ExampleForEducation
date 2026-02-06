using Example1.Abstraction;
using Example1.Models;
using Microsoft.EntityFrameworkCore;

namespace Example1.Service;

public class UserService : IUserService
{
    private readonly MarketplaceDbContext _context;
    public UserService(MarketplaceDbContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(int id)
    {
        return _context.Users
           .AsSplitQuery()
           .Include(u => u.Baskets)
               .ThenInclude(b => b.Product)
           .Include(u => u.Orders)
               .ThenInclude(o => o.OrderProducts)
           .FirstOrDefault(c => c.Id == id);

    }
}
