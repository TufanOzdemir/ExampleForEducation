using Contracts;
using MassTransit;
using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Application.Interfaces.Repository;
using OrderService.Domain.Entities;

namespace OrderService.Application.UseCases.Order.Purchase;

public sealed class PurchaseCommandHandler(
    IUnitOfWork unitOfWork,
    IPublishEndpoint publishEndpoint,
    ICurrentUserService currentUserService) : IRequestHandler<PurchaseCommand, Unit>
{
    public async Task<Unit> Handle(PurchaseCommand request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetById(currentUserService.UserId);
        if (user == null)
            throw new ArgumentException("User not found");

        if (!user.HasBasketItems())
            throw new ArgumentException("Basket is empty");

        var list = user.Baskets.Select(b => new OrderProduct
        {
            ProductId = b.ProductId,
            Count = 1,
            Product = b.Product
        }).ToList();

        var order = Domain.Entities.Order.Create(user.Id, list);
        if (!order.Validate())
            throw new InvalidOperationException("Order validation failed");

        unitOfWork.Orders.Add(order);
        unitOfWork.SaveChanges();

        var items = order.OrderProducts
            .GroupBy(op => op.ProductId)
            .Select(g => new OrderStartedItem(g.Key, g.Sum(x => x.Count)))
            .ToList();

        await publishEndpoint.Publish(new OrderStartedEvent(
            order.Id,
            order.UserId,
            order.TotalPrice,
            items), cancellationToken);

        return Unit.Value;
    }
}
