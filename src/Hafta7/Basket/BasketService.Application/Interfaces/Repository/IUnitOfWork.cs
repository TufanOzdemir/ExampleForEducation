namespace BasketService.Application.Interfaces.Repository;

public interface IUnitOfWork
{
    IBasketRepository Baskets { get; }
    IProductRepository Products { get; }
    int SaveChanges();
}
