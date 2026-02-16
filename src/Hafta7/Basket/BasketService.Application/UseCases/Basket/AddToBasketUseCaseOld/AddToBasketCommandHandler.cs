using BasketService.Application.Interfaces;
using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Application.UseCases.Basket.AddToBasketUseCaseOld
{
    public class AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        public void Execute(AddToBasketCommand request)
        {
            var product = unitOfWork.Products.GetById(request.ProductId);
            if (product == null)
                throw new ArgumentException("Product not found");

            var basket = BasketService.Domain.Entities.Basket.Create(currentUserService.UserId, product);
            unitOfWork.Baskets.Add(basket);
            unitOfWork.SaveChanges();
        }
    }
}
