using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        void Add(Basket basket);
        void ClearBasket(int userId);
    }
}
