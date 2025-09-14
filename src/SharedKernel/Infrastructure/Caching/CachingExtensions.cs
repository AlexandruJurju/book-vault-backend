using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Configuration;

namespace SharedKernel.Infrastructure.Caching;

public static class CachingExtensions
{
    public static void AddDefaultCaching(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionName,
        TimeSpan? localCacheExpiration = null,
        TimeSpan? distributedCacheExpiration = null)
    {
        services.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetConnectionStringOrThrow(connectionName));

        services.AddHybridCache(options =>
            options.DefaultEntryOptions = new HybridCacheEntryOptions
            {
                LocalCacheExpiration = localCacheExpiration ?? TimeSpan.FromMinutes(1),
                Expiration = distributedCacheExpiration ?? TimeSpan.FromMinutes(5)
            });
    }
}
