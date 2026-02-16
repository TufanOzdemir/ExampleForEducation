using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
