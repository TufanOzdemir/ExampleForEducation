using Contracts;
using MassTransit;
using BasketService.Application.Interfaces.Repository;

namespace BasketService.Application.Consumers;

public sealed class OrderStartedEventConsumer(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
    : IConsumer<IOrderStartedEvent>
{
    public async Task Consume(ConsumeContext<IOrderStartedEvent> context)
    {
        var message = context.Message;

        unitOfWork.Baskets.ClearBasket(message.UserId);
        unitOfWork.SaveChanges();

        var items = message.Items
            .Select(i => new BasketClearedItem(i.ProductId, i.Count))
            .ToList();

        await publishEndpoint.Publish(new BasketClearedEvent(
            message.CorrelationId,
            message.OrderId,
            message.UserId,
            items), context.CancellationToken);
    }
}
