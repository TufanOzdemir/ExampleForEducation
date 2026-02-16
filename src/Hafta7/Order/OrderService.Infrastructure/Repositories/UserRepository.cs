using OrderService.Application.Interfaces.Repository;
using OrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Infrastructure.Repositories;

internal class UserRepository(OrderDbContext context) : IUserRepository
{
    public User? GetById(int id)
    {
        return context.Users
            .AsSplitQuery()
            .Include(u => u.Baskets)
                .ThenInclude(b => b.Product)
            .FirstOrDefault(c => c.Id == id);
    }
}
