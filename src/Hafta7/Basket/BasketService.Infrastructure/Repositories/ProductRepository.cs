using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;

namespace BasketService.Infrastructure.Repositories;

internal class ProductRepository(BasketDbContext context) : IProductRepository
{
    public Product? GetById(int id)
    {
        return context.Products.FirstOrDefault(p => p.Id == id);
    }
}
