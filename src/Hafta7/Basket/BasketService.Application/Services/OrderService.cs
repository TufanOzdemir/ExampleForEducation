using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;
using BasketService.Application.Abstraction;

namespace BasketService.Application.Services
{
    public class OrderService(IUserService userService, IUnitOfWork unitOfWork) : IOrderService
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

            unitOfWork.Orders.Add(new Order
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
                unitOfWork.Products.ReduceStock(basket.ProductId);
            }

            unitOfWork.Baskets.ClearBasket(user.Id);
            unitOfWork.SaveChanges();
        }
    }
}
