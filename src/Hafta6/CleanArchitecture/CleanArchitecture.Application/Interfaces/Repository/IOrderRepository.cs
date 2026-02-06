using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
