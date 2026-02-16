using BasketService.Application.Interfaces;
using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;
using MediatR;

namespace BasketService.Application.UseCases.Basket.AddToBasketUseCaseOld;

public sealed class AddToBasketCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    : IRequestHandler<AddToBasketCommand, Unit>
{
    public Task<Unit> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
    {
        var product = unitOfWork.Products.GetById(request.ProductId);
        if (product == null)
            throw new ArgumentException("Product not found");

        var basket = global::BasketService.Domain.Entities.Basket.Create(currentUserService.UserId, product);
        unitOfWork.Baskets.Add(basket);
        unitOfWork.SaveChanges();

        return Unit.Task;
    }
}
