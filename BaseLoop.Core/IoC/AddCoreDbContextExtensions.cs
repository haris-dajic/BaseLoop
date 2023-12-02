using BaseLoop.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseLoop.Core.IoC;

public static class AddCoreDbContextExtensions
{
    public static IServiceCollection AddCoreDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CoreDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:BaseConnection"]);
        });

        return services;
    }
}