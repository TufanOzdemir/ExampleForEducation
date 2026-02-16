using OrderService.Domain.Common;

namespace OrderService.Domain.Entities;

public partial class Order : AggregateRoot
{
    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public static Order Create(int userId, List<OrderProduct> orderProducts)
    {
        var order = new Order
        {
            UserId = userId,
            CreateDate = DateTime.UtcNow,
            OrderProducts = orderProducts
        };

        order.CalculateTotalPrice();
        return order;
    }

    public void CalculateTotalPrice()
    {
        if (OrderProducts == null || !OrderProducts.Any())
        {
            TotalPrice = 0;
            return;
        }

        TotalPrice = OrderProducts
            .Where(op => op.Product != null)
            .Sum(op => op.Product!.Price * op.Count);
    }

    public bool Validate()
    {
        if (UserId <= 0)
        {
            return false;
        }

        if (OrderProducts == null || !OrderProducts.Any())
        {
            return false;
        }

        if (TotalPrice < 0)
        {
            return false;
        }

        return true;
    }
}
