using NotificationService.Application.Abstraction;
using NotificationService.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Application
{
    public static class ApplicationRegistrar
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotificationService, global::NotificationService.Application.Services.NotificationService>();

            // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
