using Contracts;
using MassTransit;
using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;

namespace BasketService.Application.Consumers;

public sealed class StockReserveFailedEventConsumer(IUnitOfWork unitOfWork) : IConsumer<IStockReserveFailedEvent>
{
    public Task Consume(ConsumeContext<IStockReserveFailedEvent> context)
    {
        var message = context.Message;

        foreach (var item in message.Items)
        {
            var product = unitOfWork.Products.GetById(item.ProductId);
            if (product == null) continue;

            for (var i = 0; i < item.Count; i++)
            {
                var basket = Basket.Create(message.UserId, product);
                unitOfWork.Baskets.Add(basket);
            }
        }

        unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
