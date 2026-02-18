using Contracts;
using MassTransit;
using OrderService.Application.Interfaces.Repository;

namespace OrderService.Application.Consumers;

public sealed class StockReserveFailedEventConsumer(IUnitOfWork unitOfWork) : IConsumer<IStockReserveFailedEvent>
{
    public Task Consume(ConsumeContext<IStockReserveFailedEvent> context)
    {
        var message = context.Message;
        var order = unitOfWork.Orders.GetById(message.OrderId);
        if (order == null)
        {
            return Task.CompletedTask;
        }

        order.MarkCancelled();
        unitOfWork.SaveChanges();

        return Task.CompletedTask;
    }
}
