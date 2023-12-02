using System.Reflection;
using BaseLoop.Core.Infrastructure.Authentication;
using BaseLoop.Core.Infrastructure.Behaviors;
using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Core.Infrastructure.Data.Repositories;
using BaseLoop.Core.Infrastructure.Data.Repositories.Implementations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BaseLoop.Core.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assemblies)
    {
        var asses = new List<Assembly>();
        asses.AddRange(assemblies);
        asses.Add(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDispatcher, CommandDispatcher>();

        return serviceCollection;
    }

    public static IServiceCollection AddCoreMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(typeof(CoreAssembly).Assembly));
        return serviceCollection;
    }

    public static IServiceCollection AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        return services;
    }

    public static IServiceCollection AddPermissionsService(this IServiceCollection services)
    {
        services.AddScoped<IPermissionService, PermissionService>();
        return services;
    }
}