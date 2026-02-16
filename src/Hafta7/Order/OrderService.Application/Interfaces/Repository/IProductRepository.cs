using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces.Repository;

public interface IProductRepository
{
    Product? GetById(int id);
    void ReduceStock(int productId);
}
