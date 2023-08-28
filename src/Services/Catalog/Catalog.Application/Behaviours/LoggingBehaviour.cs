namespace Catalog.Application.Behaviours;

public sealed class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handling {Name} , {DateTimeUtc}", typeof(TRequest).Name, DateTime.UtcNow);
            
            TResponse response = await next();
            
            _logger.LogInformation("Handled {Name} successfully on {DateTimeUtc}", typeof(TRequest).Name, DateTime.UtcNow);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling {Name} , {DateTimeUtc}", typeof(TRequest).Name, DateTime.UtcNow);
            throw;
        }
    }
}