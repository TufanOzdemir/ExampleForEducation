using BasketService.Application.Interfaces;
using BasketService.Application.Interfaces.Repository;
using BasketService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Infrastructure
{
    public static class InfrastructureRegistrar
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenGenerator, JWTTokenGenerator>();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

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
