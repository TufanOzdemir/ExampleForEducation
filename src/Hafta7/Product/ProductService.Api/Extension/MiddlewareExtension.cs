namespace ProductService.Api.Extension;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ProductService.Api.Middleware.RequestLogMiddleware>();
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ProductService.Api.Middleware.ExceptionHandlingMiddleware>();
    }
}
