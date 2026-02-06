using NTier.Data.Abstraction;
using NTier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Data.Repositories
{
    internal class UnitOfWork(MarketplaceDbContext _context, IProductRepository productRepository, IOrderRepository orderRepository, IBasketRepository basketRepository, IUserRepository userRepository) : IUnitOfWork
    {
        public IProductRepository Products => productRepository;
        public IOrderRepository Orders => orderRepository;
        public IBasketRepository Baskets => basketRepository;
        public IUserRepository Users => userRepository;

        public int SaveChanges()
        {
            // Tüm repository'lerdeki değişiklikleri tek seferde veritabanına gönderir
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            // Veritabanı bağlantısını güvenli bir şekilde kapatır
            _context.Dispose();
        }
    }
}
