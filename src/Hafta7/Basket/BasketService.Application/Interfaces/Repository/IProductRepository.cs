using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product? GetById(int id);
    }
}
