using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Infrastructure;

/// <summary>
/// Notification servisi veritabanı veya harici altyapı kullanmıyor; sadece event handler içerir.
/// Bu sınıf solution build için placeholder olarak bırakıldı.
/// </summary>
public static class InfrastructureRegistrar
{
    public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Notification servisi sadece MediatR event handler kullanıyor, altyapı kaydı yok.
    }
}
