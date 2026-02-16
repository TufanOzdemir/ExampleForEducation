using NotificationService.Domain.Common;

namespace NotificationService.Domain.Entities;

public partial class OrderProduct : Entity
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Count { get; set; }

    public virtual Product Product { get; set; } = null!;
}
