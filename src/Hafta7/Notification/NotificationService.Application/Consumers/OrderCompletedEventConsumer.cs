using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace NotificationService.Application.Consumers;

public sealed class OrderCompletedEventConsumer(ILogger<OrderCompletedEventConsumer> logger)
    : IConsumer<IOrderCompletedEvent>
{
    public Task Consume(ConsumeContext<IOrderCompletedEvent> context)
    {
        var message = context.Message;

        logger.LogInformation(
            "[SAGA] Sipariş tamamlandı - OrderId: {OrderId}, UserId: {UserId}, TotalPrice: {TotalPrice}. SMS ve E-posta gönderiliyor.",
            message.OrderId, message.UserId, message.TotalPrice);

        // Gerçek uygulamada: SMS/E-posta sağlayıcı entegrasyonu (Twilio, SendGrid vb.)
        // await _smsService.SendAsync(userPhone, $"Siparişiniz #{message.OrderId} tamamlandı.");
        // await _emailService.SendAsync(userEmail, "Sipariş Tamamlandı", $"Toplam: {message.TotalPrice}");

        return Task.CompletedTask;
    }
}
