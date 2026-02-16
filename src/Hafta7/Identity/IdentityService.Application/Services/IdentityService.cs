using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using IdentityService.Application.Abstraction;

namespace IdentityService.Application.Services
{
    public class IdentityService(IUserService userService, IUnitOfWork unitOfWork) : IIdentityService
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
