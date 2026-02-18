using Contracts;
using MassTransit;
using BasketService.Application.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace BasketService.Application.Consumers;

public sealed class OrderStartedEventConsumer(
    IUnitOfWork unitOfWork,
    IPublishEndpoint publishEndpoint,
    ILogger<OrderStartedEventConsumer> logger)
    : IConsumer<IOrderStartedEvent>
{
    public async Task Consume(ConsumeContext<IOrderStartedEvent> context)
    {
        var message = context.Message;

        try
        {
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
        catch (Exception ex)
        {
            logger.LogError(ex,
                "[SAGA Fail] OrderStartedEvent işlenirken hata - OrderId: {OrderId}, UserId: {UserId}. BasketClearedFailedEvent fırlatılıyor.",
                message.OrderId, message.UserId);

            await publishEndpoint.Publish(new OrderStartedFailedEvent(
                message.CorrelationId,
                message.OrderId,
                message.UserId,
                ex.Message), context.CancellationToken);

            // Throw etmiyoruz: compensating event gönderildi, OrderService siparişi iptal edecek.
            // Tekrar deneme yapılmaz, mesaj acknowledge edilir.
        }
    }
}
