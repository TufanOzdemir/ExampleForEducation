using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
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
