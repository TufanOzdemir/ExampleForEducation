using BasketService.Application.Abstraction;
using BasketService.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Application
{
    public static class ApplicationRegistrar
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBasketService, global::BasketService.Application.Services.BasketService>();
            services.AddScoped<IOrderService, OrderService>();

            // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
