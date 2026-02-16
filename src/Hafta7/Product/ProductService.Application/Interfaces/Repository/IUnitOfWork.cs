namespace ProductService.Application.Interfaces.Repository;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    int SaveChanges();
}
