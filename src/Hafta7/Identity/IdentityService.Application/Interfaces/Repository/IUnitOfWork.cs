using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityService.Application.Interfaces.Repository
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
