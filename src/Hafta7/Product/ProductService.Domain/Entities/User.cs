using ProductService.Domain.Common;

namespace ProductService.Domain.Entities;

public partial class User : AggregateRoot
{
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public bool HasBasketItems()
    {
        return Baskets != null && Baskets.Any();
    }
}
