using BaseLoop.Core.Infrastructure.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BaseLoop.Core.IoC;

public static class LoggerExtensions
{
    public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        var seqUrl = configuration["Logging:seq.url"];
        services.AddLogging(loggingBuilder => loggingBuilder.AddSeq(seqUrl));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));

        return services;
    }
}