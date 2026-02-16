using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces.Repository
{
    public interface IBasketRepository
    {
        void Add(Basket basket);
        void ClearBasket(int userId);
    }
}
