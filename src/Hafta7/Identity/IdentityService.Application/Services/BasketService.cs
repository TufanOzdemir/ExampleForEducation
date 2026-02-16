using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using IdentityService.Application.Abstraction;

namespace IdentityService.Application.Services
{
    public class BasketService(IUserService userService, IUnitOfWork unitOfWork) : IBasketService
    {
        public void AddToBasket(int userId, int productId)
        {
            var user = userService.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var product = unitOfWork.Products.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (product.Stock <= 0)
            {
                throw new ArgumentException("Product is out of stock");
            }

            unitOfWork.Baskets.Add(new Basket
            {
                ProductId = product.Id,
                UserId = user.Id
            });

            unitOfWork.SaveChanges();
        }
    }
}
