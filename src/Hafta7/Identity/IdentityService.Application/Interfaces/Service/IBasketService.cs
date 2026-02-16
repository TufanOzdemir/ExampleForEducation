namespace IdentityService.Application.Abstraction
{
    public interface IBasketService
    {
        void AddToBasket(int userId, int productId);
    }
}
