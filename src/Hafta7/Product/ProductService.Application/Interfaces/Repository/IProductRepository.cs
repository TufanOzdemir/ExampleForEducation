using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Repository;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    void ReduceStock(int productId);
}
