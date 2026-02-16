using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces.Repository;

public interface IBasketRepository
{
    void ClearBasket(int userId);
}
