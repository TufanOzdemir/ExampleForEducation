using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using ProductService.Domain.Events;
using MediatR;

namespace ProductService.Application.UseCases.Orders.Purchase;

public sealed class PurchaseCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, ICurrentUserService currentUserService) : IRequestHandler<PurchaseCommand, Unit>
{
    public async Task<Unit> Handle(PurchaseCommand request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetById(currentUserService.UserId);
        if (user == null)
            throw new ArgumentException("User not found");

        if (!user.HasBasketItems())
            throw new ArgumentException("Basket is empty");

        var baskets = user.Baskets.ToList();

        var list = user.Baskets.Select(b => new OrderProduct
        {
            ProductId = b.ProductId,
            Count = 1,
            Product = b.Product
        }).ToList();

        var order = Order.Create(user.Id, list);
        if (!order.Validate())
            throw new InvalidOperationException("Order validation failed");

        unitOfWork.Orders.Add(order);

        foreach (var item in user.Baskets)
        {
            item.Product.ReduceStock(1);
        }

        unitOfWork.Baskets.ClearBasket(user.Id);
        unitOfWork.SaveChanges();

        await mediator.Publish(new OrderCreatedEvent(order.Id, order.UserId, order.TotalPrice), cancellationToken);
        
        return Unit.Value;
    }
}
