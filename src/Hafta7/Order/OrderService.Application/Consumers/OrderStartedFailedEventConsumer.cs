using Contracts;
using MassTransit;
using MediatR;
using OrderService.Application.UseCases.Order.CancelOrder;

namespace OrderService.Application.Consumers;

/// <summary>
/// BasketService sepet temizlerken hata verdiğinde fırlatılan OrderStartedFailedEvent'i dinler.
/// CancelOrderCommand ile siparişi Cancelled yaparak compensating transaction uygular.
/// </summary>
public sealed class OrderStartedFailedEventConsumer(IMediator mediator) : IConsumer<IOrderStartedFailedEvent>
{
    public async Task Consume(ConsumeContext<IOrderStartedFailedEvent> context)
    {
        await mediator.Send(new CancelOrderCommand(context.Message.OrderId), context.CancellationToken);
    }
}
