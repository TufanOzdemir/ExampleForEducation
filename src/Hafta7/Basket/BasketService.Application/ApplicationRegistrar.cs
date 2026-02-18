using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BasketService.Application.Consumers;

namespace BasketService.Application
{
    public static class ApplicationRegistrar
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
        }

        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterApplicationServices();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderStartedEventConsumer>();
                x.AddConsumer<StockReserveFailedEventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"] ?? "localhost", "/", h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"] ?? "guest");
                        h.Password(configuration["RabbitMQ:Password"] ?? "guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
