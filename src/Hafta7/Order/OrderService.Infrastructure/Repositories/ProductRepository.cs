using OrderService.Application.Interfaces.Repository;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories;

internal class ProductRepository(OrderDbContext context) : IProductRepository
{
    public Product? GetById(int id) => context.Products.FirstOrDefault(p => p.Id == id);

    public void ReduceStock(int productId)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.ReduceStock(1);
            context.Products.Update(product);
        }
    }
}
