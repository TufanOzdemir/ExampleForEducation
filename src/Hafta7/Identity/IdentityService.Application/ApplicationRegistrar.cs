using IdentityService.Application.Abstraction;
using IdentityService.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Application
{
    public static class ApplicationRegistrar
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityService, global::IdentityService.Application.Services.IdentityService>();

            // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
