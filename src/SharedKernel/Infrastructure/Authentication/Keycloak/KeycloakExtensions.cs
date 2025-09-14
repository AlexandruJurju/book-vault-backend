using BookVault.AspireConstants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Infrastructure.Authentication.Keycloak;

public static class KeycloakExtensions
{
    public static void AddDefaultKeycloakAuthentication(this IServiceCollection services)
    {
        // todo: const realm name
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddKeycloakJwtBearer(Components.KeyCloak,
                "template-realm",
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Audience = "account";
                }
            );
    }
}
