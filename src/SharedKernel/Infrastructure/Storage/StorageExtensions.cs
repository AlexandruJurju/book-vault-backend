using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Configuration;

namespace SharedKernel.Infrastructure.Storage;

public static class StorageExtensions
{
    public static void AddDefaultAzureBlobStorage(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionName
    )
    {
        services.AddOptionsWithValidation<StorageOptions>(StorageOptions.SectionName);

        services.AddSingleton<IBlobStorage, BlobStorage>();

        services.AddSingleton(_ => new BlobServiceClient(configuration.GetConnectionStringOrThrow(connectionName)));
    }
}
