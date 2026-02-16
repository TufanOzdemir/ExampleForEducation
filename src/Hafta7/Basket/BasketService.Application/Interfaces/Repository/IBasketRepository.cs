using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        void Add(Basket basket);
        void ClearBasket(int userId);
    }
}
