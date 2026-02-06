using System;
using System.Collections.Generic;

namespace NTier.Data.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
