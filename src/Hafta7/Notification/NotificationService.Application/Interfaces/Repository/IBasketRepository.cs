using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        void Add(Basket basket);
        void ClearBasket(int userId);
    }
}
