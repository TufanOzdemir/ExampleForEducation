using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces.Repository;

public interface IOrderRepository
{
    void Add(Order order);
    Order? GetById(int id);
}
