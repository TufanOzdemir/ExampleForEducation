using Azure.Core;
using Example1.Abstraction;
using Example1.Models;

namespace Example1.Service
{
    public class OrderService(IUserService userService, MarketplaceDbContext marketplaceDbContext) : IOrderService
    {
        public void Purchase(int userId)
        {
            var user = userService.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (!user.Baskets.Any())
            {
                throw new ArgumentException("Basket is empty");
            }

            marketplaceDbContext.Orders.Add(new Order
            {
                UserId = user.Id,
                CreateDate = DateTime.UtcNow,
                OrderProducts = user.Baskets.Select(b => new OrderProduct
                {
                    ProductId = b.ProductId,
                    Count = 1
                }).ToList()
            });

            foreach (var basket in user.Baskets)
            {
                basket.Product.Stock -= 1;
                marketplaceDbContext.Products.Update(basket.Product);
            }

            marketplaceDbContext.Baskets.RemoveRange(user.Baskets);
            marketplaceDbContext.SaveChanges();
        }
    }
}
