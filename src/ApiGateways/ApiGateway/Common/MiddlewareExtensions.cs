namespace ApiGateway.Common;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenValidationMiddleware>();
    }
}