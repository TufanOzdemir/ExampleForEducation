using Contracts;
using MassTransit;
using ProductService.Application.Interfaces.Repository;

namespace ProductService.Application.Consumers;

public sealed class BasketClearedEventConsumer(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
    : IConsumer<IBasketClearedEvent>
{
    public async Task Consume(ConsumeContext<IBasketClearedEvent> context)
    {
        var message = context.Message;

        // Önce tüm ürünlerde yeterli stok var mı kontrol et (kısmi düşüşü önlemek için)
        foreach (var item in message.Items)
        {
            var product = unitOfWork.Products.GetById(item.ProductId);
            if (product == null || !product.CanPurchase(item.Count))
            {
                var failedItems = message.Items
                    .Select(i => new StockReserveFailedItem(i.ProductId, i.Count))
                    .ToList();
                var reason = product == null
                    ? $"Ürün bulunamadı: {item.ProductId}"
                    : $"Yetersiz stok. Ürün: {item.ProductId}, Mevcut: {product.Stock}, İstenen: {item.Count}";

                await publishEndpoint.Publish(new StockReserveFailedEvent(
                    message.OrderId,
                    message.UserId,
                    failedItems,
                    reason), context.CancellationToken);
                return;
            }
        }

        foreach (var item in message.Items)
        {
            unitOfWork.Products.ReduceStock(item.ProductId, item.Count);
        }

        unitOfWork.SaveChanges();

        await publishEndpoint.Publish(new StockReservedEvent(
            message.OrderId,
            message.UserId), context.CancellationToken);
    }
}
