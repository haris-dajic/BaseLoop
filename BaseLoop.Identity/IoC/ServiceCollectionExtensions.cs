using System.Numerics;
using System.Reflection;
using BaseLoop.Core.Infrastructure.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BaseLoop.Identity.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddValidatorsFromAssembly(typeof(IdentityAssembly).Assembly);
        return services;
    }

    public static IServiceCollection AddIdentityMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IdentityAssembly).Assembly));
        return serviceCollection;
    }
}