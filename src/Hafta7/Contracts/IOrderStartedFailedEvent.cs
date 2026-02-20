namespace Contracts;

/// <summary>
/// BasketService'te sepet temizlenirken hata oluştuğunda fırlatılır.
/// OrderService bu event'i dinleyerek siparişi Cancelled yapar.
/// </summary>
public interface IOrderStartedFailedEvent
{
    int OrderId { get; }
    int UserId { get; }
    string Reason { get; }
}
