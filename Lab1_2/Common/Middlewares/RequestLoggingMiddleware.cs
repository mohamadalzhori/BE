using System.Text;

namespace Lab_1.Common.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        // Everything before await _next(context) is executed on the request

        // Log the request method, path, and query parameters
        _logger.LogInformation($"Request Method: {context.Request.Method}, Path: {context.Request.Path}, Query: {context.Request.QueryString}");

        // Log request headers
        LogRequestHeaders(context);

        // Log request body (if applicable)
        if (context.Request.Body != null && context.Request.Body.CanRead)
        {
            await LogRequestBody(context);
        }

        // Capture the current timestamp
        DateTime startTime = DateTime.UtcNow;

        // Call the next middleware in the pipeline
        await _next(context);

        // everything here after the await _next(context) is executed on the response on it's way back from the application

        // Log response status code and elapsed time
        LogResponse(context, startTime);
    }

    private void LogRequestHeaders(HttpContext context)
    {
        var logs = new StringBuilder();

        foreach (var (key, value) in context.Request.Headers)
        {
            logs.Append($"Request Header: {key}: {value}\n");
        }

        _logger.LogInformation(logs.ToString());
    }

    private async Task LogRequestBody(HttpContext context)
    {
        context.Request.EnableBuffering();
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Request.Body.Position = 0; // Reset the request body stream position for next middleware

        _logger.LogInformation($"Request Body: {requestBody}");
    }

    private void LogResponse(HttpContext context, DateTime startTime)
    {
        var statusCode = context.Response.StatusCode;
        var elapsed = DateTime.UtcNow - startTime;

        _logger.LogInformation($"Response Status Code: {statusCode}, Elapsed Time: {elapsed.TotalMilliseconds}ms");
    }
}
