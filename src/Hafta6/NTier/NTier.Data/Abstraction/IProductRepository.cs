using NTier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Data.Abstraction
{
    public interface IProductRepository
    {
        Product GetById(int id);

        void ReduceStock(int productId);
    }
}
