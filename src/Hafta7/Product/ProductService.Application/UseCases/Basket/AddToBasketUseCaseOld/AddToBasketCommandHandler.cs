using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Application.UseCases.Basket.AddToBasketUseCaseOld
{
    public class AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        public void Execute(AddToBasketCommand request)
        {
            var product = unitOfWork.Products.GetById(request.ProductId);
            if (product == null)
                throw new ArgumentException("Product not found");

            var basket = ProductService.Domain.Entities.Basket.Create(currentUserService.UserId, product);
            unitOfWork.Baskets.Add(basket);
            unitOfWork.SaveChanges();
        }
    }
}
