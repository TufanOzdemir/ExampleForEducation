using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product GetById(int id);

        void ReduceStock(int productId);
    }
}
