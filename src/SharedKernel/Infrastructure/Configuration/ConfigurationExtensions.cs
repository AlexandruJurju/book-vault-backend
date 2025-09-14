using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace SharedKernel.Infrastructure.Configuration;

public static class ConfigurationExtensions
{
    public static void AddOptionsWithValidation<TSetting>(
        this IServiceCollection services,
        string section,
        string? name = null,
        Action<TSetting>? configure = null
    )
        where TSetting : class, new()
    {
        services
            .AddOptionsWithValidateOnStart<TSetting>(name)
            .Configure(options => configure?.Invoke(options))
            .BindConfiguration(section)
            .ValidateDataAnnotations();

        services.TryAddSingleton(sp =>
        {
            IOptions<TSetting> options = sp.GetRequiredService<IOptions<TSetting>>();
            TSetting setting = options.Value;
            return setting;
        });
    }

    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString(name);

        ArgumentNullException.ThrowIfNull(connectionString);

        return connectionString;
    }

    public static T GetValueOrThrow<T>(this IConfiguration configuration, string name)
    {
        T? value = configuration.GetValue<T?>(name);

        ArgumentNullException.ThrowIfNull(value);

        return value;
    }
}
