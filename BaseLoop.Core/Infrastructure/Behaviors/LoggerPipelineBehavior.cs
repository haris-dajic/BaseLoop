using BaseLoop.Core.Infrastructure.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BaseLoop.Core.Infrastructure.Behaviors;

public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where
    TRequest : ICommand<TResponse>
{
    private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request {@requestdName} at {@date}", typeof(TRequest).Name, DateTime.UtcNow);

        //TODO Chech the result and if error, log that
        var result = await next();

        _logger.LogInformation("Completed request {@requestName} at {@date}", typeof(TRequest).Name, DateTime.UtcNow);

        return result;
    }
}