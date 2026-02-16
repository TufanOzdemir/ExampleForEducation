using OrderService.Application.Interfaces.Repository;

namespace OrderService.Infrastructure.Repositories;

internal class UnitOfWork(
    OrderDbContext context,
    IProductRepository productRepository,
    IOrderRepository orderRepository,
    IBasketRepository basketRepository,
    IUserRepository userRepository) : IUnitOfWork
{
    public IProductRepository Products => productRepository;
    public IOrderRepository Orders => orderRepository;
    public IBasketRepository Baskets => basketRepository;
    public IUserRepository Users => userRepository;

    public int SaveChanges() => context.SaveChanges();
}
