using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        void Add(Basket basket);
        void ClearBasket(int userId);
    }
}
