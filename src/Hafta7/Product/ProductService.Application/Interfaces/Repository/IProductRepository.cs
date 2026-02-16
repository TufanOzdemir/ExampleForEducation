using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product GetById(int id);

        void ReduceStock(int productId);
    }
}
