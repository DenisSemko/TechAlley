namespace IdentityServer.Application.Behaviours;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = GetStatusCode(exception);

        ContextResponse response = new (exception.Message, exception.GetType().FullName, exception.StackTrace, GetErrors(exception));

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            KeyNotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    
    private static IEnumerable<ValidationFailure> GetErrors(Exception exception)
    {
        IEnumerable<ValidationFailure> errors = null;
        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors;
        }
        return errors;
    }
}