using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories;

internal class ProductRepository(ProductDbContext context) : IProductRepository
{
    public List<Product> GetAll() => context.Products.ToList();

    public Product? GetById(int id) => context.Products.FirstOrDefault(p => p.Id == id);

    public void ReduceStock(int productId, int quantity = 1)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.ReduceStock(quantity);
            context.Products.Update(product);
        }
    }
}
