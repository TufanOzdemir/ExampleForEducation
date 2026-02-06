using NTier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Data.Abstraction
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
