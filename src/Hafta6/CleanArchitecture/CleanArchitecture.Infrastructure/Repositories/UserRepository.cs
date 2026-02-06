using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal class UserRepository(MarketplaceDbContext _context) : IUserRepository
{
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _context.Users
           .AsSplitQuery()
           .Include(u => u.Baskets)
               .ThenInclude(b => b.Product)
           .Include(u => u.Orders)
               .ThenInclude(o => o.OrderProducts)
               .ThenInclude(op => op.Product)
            .Include(u => u.Permissions)
           .FirstOrDefault(c => c.Id == id);
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.Include(c => c.Permissions).FirstOrDefault(c => c.Email == email);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }
}
