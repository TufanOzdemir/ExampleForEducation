using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBasketRepository Baskets { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }

        int SaveChanges();
    }
}
