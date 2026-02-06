using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.Data.Abstraction;
using NTier.Data.Entities;
using NTier.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Data
{
    public static class DataRegistrar
    {
        public static void RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<MarketplaceDbContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });
        }
    }
}
