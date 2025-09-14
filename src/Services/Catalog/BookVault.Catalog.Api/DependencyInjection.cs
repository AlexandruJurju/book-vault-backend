using SharedKernel.Api.Exceptions;
using SharedKernel.Api.Swagger;

namespace BookVault.Catalog.Api;

public static class DependencyInjection
{
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddCommonSwagger();
    }
}
