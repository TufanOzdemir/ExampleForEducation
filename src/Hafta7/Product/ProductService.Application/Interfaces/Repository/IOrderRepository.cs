using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
