using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories;

internal class UserRepository(IdentityDbContext context) : IUserRepository
{
    public List<User> GetAll()
    {
        return context.Users.ToList();
    }

    public User? GetById(int id)
    {
        return context.Users
            .Include(u => u.Permissions)
            .FirstOrDefault(c => c.Id == id);
    }

    public User? GetByEmail(string email)
    {
        return context.Users.Include(c => c.Permissions).FirstOrDefault(c => c.Email == email);
    }

    public void Add(User user)
    {
        context.Users.Add(user);
    }
}
