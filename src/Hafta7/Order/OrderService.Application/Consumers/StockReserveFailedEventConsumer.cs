using Contracts;
using MediatR;
using MassTransit;
using OrderService.Application.UseCases.Order.CancelOrder;

namespace OrderService.Application.Consumers;

public sealed class StockReserveFailedEventConsumer(IMediator mediator) : IConsumer<IStockReserveFailedEvent>
{
    public async Task Consume(ConsumeContext<IStockReserveFailedEvent> context)
    {
        await mediator.Send(new CancelOrderCommand(context.Message.OrderId), context.CancellationToken);
    }
}
