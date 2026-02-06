using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UseCases.Basket.AddToBasketUseCaseOld
{
    public class AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        public void Execute(AddToBasketCommand request)
        {
            var product = unitOfWork.Products.GetById(request.ProductId);
            if (product == null)
                throw new ArgumentException("Product not found");

            var basket = CleanArchitecture.Domain.Entities.Basket.Create(currentUserService.UserId, product);
            unitOfWork.Baskets.Add(basket);
            unitOfWork.SaveChanges();
        }
    }
}
