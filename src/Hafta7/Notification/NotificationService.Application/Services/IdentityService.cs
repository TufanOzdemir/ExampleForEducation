using NotificationService.Application.Interfaces.Repository;
using NotificationService.Domain.Entities;
using NotificationService.Application.Abstraction;

namespace NotificationService.Application.Services
{
    public class NotificationService(IUserService userService, IUnitOfWork unitOfWork) : INotificationService
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
