using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public partial class Product : Entity
{
    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public bool IsInStock(int quantity = 1)
    {
        return Stock >= quantity;
    }

    public bool CanPurchase(int quantity)
    {
        return IsInStock(quantity) && quantity > 0;
    }

    public void ReduceStock(int quantity)
    {
        if (!CanPurchase(quantity))
        {
            throw new InvalidOperationException($"Cannot reduce stock. Available: {Stock}, Requested: {quantity}");
        }

        Stock -= quantity;
    }
}
