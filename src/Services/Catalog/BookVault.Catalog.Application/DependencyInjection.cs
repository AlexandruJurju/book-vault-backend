using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.CQRS.Mediator;
using SharedKernel.Application.EventBus;

namespace BookVault.Catalog.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDefaultMediatR<IApplicationAssemblyMarker>();

        services.AddValidatorsFromAssembly(typeof(IApplicationAssemblyMarker).Assembly, includeInternalTypes: true);
    }
}
