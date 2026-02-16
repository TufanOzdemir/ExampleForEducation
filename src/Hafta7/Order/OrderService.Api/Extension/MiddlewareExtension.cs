namespace Example1.Extension;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Example1.Middleware.RequestLogMiddleware>();
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Example1.Middleware.ExceptionHandlingMiddleware>();
    }
}
