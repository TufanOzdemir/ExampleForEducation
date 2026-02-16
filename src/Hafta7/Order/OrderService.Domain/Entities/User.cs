using OrderService.Domain.Common;

namespace OrderService.Domain.Entities;

public partial class User : AggregateRoot
{
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public bool HasBasketItems() => Baskets != null && Baskets.Any();
}
