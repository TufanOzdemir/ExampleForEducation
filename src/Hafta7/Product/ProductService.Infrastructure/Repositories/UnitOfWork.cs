using ProductService.Application.Interfaces.Repository;

namespace ProductService.Infrastructure.Repositories;

internal class UnitOfWork(ProductDbContext context, IProductRepository productRepository) : IUnitOfWork
{
    public IProductRepository Products => productRepository;

    public int SaveChanges() => context.SaveChanges();
}
