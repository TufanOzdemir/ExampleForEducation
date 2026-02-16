using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product GetById(int id);

        void ReduceStock(int productId);
    }
}
