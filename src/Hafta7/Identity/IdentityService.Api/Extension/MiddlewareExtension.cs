namespace IdentityService.Api.Extension;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<IdentityService.Api.Middleware.RequestLogMiddleware>();
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<IdentityService.Api.Middleware.ExceptionHandlingMiddleware>();
    }
}
