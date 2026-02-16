namespace ProductService.Api.Middleware;

public class RequestLogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLogMiddleware> _logger;

    public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogWarning("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);
        await _next(context);
        _logger.LogWarning($"Finished handling request. Status: {context.Response.StatusCode}");
    }
}
