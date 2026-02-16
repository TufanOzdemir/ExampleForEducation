using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
