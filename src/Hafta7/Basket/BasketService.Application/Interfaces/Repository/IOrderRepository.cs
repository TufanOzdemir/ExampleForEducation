using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
