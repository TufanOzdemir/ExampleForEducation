using ProductService.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProductService.Application.EventHandlers;

/// <summary>
/// OrderCreatedEvent MediatR notification handler.
/// </summary>
public sealed class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[Domain Event] Order created - OrderId: {OrderId}, UserId: {UserId}, TotalPrice: {TotalPrice}, EventId: {EventId}",
            notification.OrderId, notification.UserId, notification.TotalPrice, notification.EventId);
        return Task.CompletedTask;
    }
}
