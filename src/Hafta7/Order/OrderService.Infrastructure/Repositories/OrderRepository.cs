using Microsoft.EntityFrameworkCore;
using OrderService.Application.Interfaces.Repository;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories;

internal class OrderRepository(OrderDbContext context) : IOrderRepository
{
    public void Add(Order order) => context.Orders.Add(order);

    public Order? GetById(int id) => context.Orders
        .Include(o => o.OrderProducts)
        .FirstOrDefault(o => o.Id == id);
}
