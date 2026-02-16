using BasketService.Application.Interfaces.Repository;

namespace BasketService.Infrastructure.Repositories;

internal class UnitOfWork(BasketDbContext context, IProductRepository productRepository, IBasketRepository basketRepository) : IUnitOfWork
{
    public IProductRepository Products => productRepository;
    public IBasketRepository Baskets => basketRepository;

    public int SaveChanges() => context.SaveChanges();
}
