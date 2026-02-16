using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Repositories;

internal class ProductRepository(MarketplaceDbContext _context) : IProductRepository
{
    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void ReduceStock(int productId)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == productId);
        product.ReduceStock(1);
        _context.Products.Update(product);
    }
}
