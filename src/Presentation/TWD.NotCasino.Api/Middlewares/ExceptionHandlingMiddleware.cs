using System.Net;
using System.Text.Json;

namespace TWD.NotCasino.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context); // пропускаем дальше по пайплайну
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Произошла ошибка при обработке запроса");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = exception switch
        {
            ArgumentNullException => HttpStatusCode.BadRequest,
            ArgumentException => HttpStatusCode.BadRequest,
            KeyNotFoundException => HttpStatusCode.NotFound,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        };

        var response = new
        {
            error = exception.Message,
            code = (int)statusCode
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, _options));
    }
}


}