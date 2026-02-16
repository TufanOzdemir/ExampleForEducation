using ProductService.Application.Abstraction;
using ProductService.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProductService.Application
{
    public static class ApplicationRegistrar
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, global::ProductService.Application.Services.ProductService>();

            // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
