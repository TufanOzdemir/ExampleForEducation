using IdentityService.Domain.Common;

namespace IdentityService.Domain.Entities;

public partial class Basket : AggregateRoot
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public static Basket Create(int userId, Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (!product.IsInStock())
        {
            throw new InvalidOperationException($"Product {product.Title} is not in stock");
        }

        return new Basket
        {
            UserId = userId,
            ProductId = product.Id,
            Product = product
        };
    }

    public bool CanAddToBasket()
    {
        return Product != null && Product.IsInStock();
    }
}
