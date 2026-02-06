using NTier.Data.Abstraction;
using NTier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Java;
using System.Text;

namespace NTier.Data.Repositories
{
    internal class ProductRepository(MarketplaceDbContext marketplaceDbContext) : IProductRepository
    {
        public Product GetById(int id)
        {
            return marketplaceDbContext.Products.Find(id);
        }

        public void ReduceStock(int productId)
        {
            var product = GetById(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }
            if (product.Stock < 1)
            {
                throw new ArgumentException("Insufficient stock");
            }
            product.Stock -= 1;
            marketplaceDbContext.Products.Update(product);
        }
    }
}
