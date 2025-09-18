using TWD.NotCasino.Api.Middlewares;

namespace TWD.NotCasino.Api.Helpers.Extensions;

public static class ExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
