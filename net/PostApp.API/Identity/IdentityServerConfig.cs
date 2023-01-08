using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PostApp.API.Services;

namespace PostApp.API.Identity;

public static class IdentityServerConfig
{
    private static List<ApiScope> ApiScopes => new()
    {
        new("PostAppAPI", "PostAppAPI")
    };

    private static List<Client> Clients = new()
    {
        new()
        {
            ClientId = "AngularSPA",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new("secret".Sha256()) },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "PostAppAPI"
            }
        }
    };

    private static readonly List<IdentityResource> IdentityResources = new()
    {
        new IdentityResources.Profile(),
        new IdentityResources.OpenId()
    };

    public static IServiceCollection ConfigureIdentityServer(this IServiceCollection services)
    {
        services
            .AddIdentityServer()
            .AddCorsPolicyService<CorsPolicyService>()
            .AddInMemoryApiScopes(ApiScopes)
            .AddInMemoryIdentityResources(IdentityResources)
            .AddInMemoryClients(Clients)
            .AddDeveloperSigningCredential()
            .AddProfileService<ProfileService>();

        services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerValidationService>();
        services.AddTransient<IProfileService, ProfileService>();
        
        return services;
    }
}
