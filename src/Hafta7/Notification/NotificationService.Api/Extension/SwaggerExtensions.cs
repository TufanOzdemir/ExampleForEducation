using Microsoft.OpenApi;

namespace NotificationService.Api.Extension;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerWithJwt(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NotificationService API",
                Version = "v1",
                Description = "JWT ile korumalı endpoint'ler için sağ üstte **Authorize** butonuna tıklayıp token'ı yapıştırın (Bearer öneki otomatik eklenir)."
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT token girin. Örnek: eyJhbGc... (Bearer öneki otomatik eklenir)",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });

            c.AddSecurityRequirement(document =>
            {
                var schemeRef = new OpenApiSecuritySchemeReference("Bearer", document, null);
                return new OpenApiSecurityRequirement
                {
                    [schemeRef] = new List<string>()
                };
            });
        });

        return services;
    }
}
