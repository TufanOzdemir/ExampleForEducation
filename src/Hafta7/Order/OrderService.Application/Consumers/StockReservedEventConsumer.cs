using Contracts;
using MassTransit;
using OrderService.Application.Interfaces.Repository;

namespace OrderService.Application.Consumers;

public sealed class StockReservedEventConsumer(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
    : IConsumer<IStockReservedEvent>
{
    public async Task Consume(ConsumeContext<IStockReservedEvent> context)
    {
        var message = context.Message;
        var order = unitOfWork.Orders.GetById(message.OrderId);
        if (order == null)
        {
            return;
        }

        order.MarkCompleted();
        unitOfWork.SaveChanges();

        await publishEndpoint.Publish(new OrderCompletedEvent(
            message.OrderId,
            message.UserId,
            order.TotalPrice), context.CancellationToken);
    }
}
