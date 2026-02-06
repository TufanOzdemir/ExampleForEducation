using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product GetById(int id);

        void ReduceStock(int productId);
    }
}
