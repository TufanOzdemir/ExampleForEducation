using Azure.Core;
using Example1.Abstraction;
using Example1.Models;

namespace Example1.Service
{
    public class BasketService(IUserService userService, MarketplaceDbContext marketplaceDbContext) : IBasketService
    {
        public void AddToBasket(int userId, int productId)
        {
            var user = userService.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var product = marketplaceDbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (product.Stock <= 0)
            {
                throw new ArgumentException("Product is out of stock");
            }

            user.Baskets.Add(new Basket
            {
                ProductId = product.Id,
                UserId = user.Id
            });

            marketplaceDbContext.SaveChanges();
        }
    }
}
