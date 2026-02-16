using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using ProductService.Application.Abstraction;

namespace ProductService.Application.Services
{
    public class ProductService(IUserService userService, IUnitOfWork unitOfWork) : IProductService
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
