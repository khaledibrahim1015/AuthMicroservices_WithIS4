using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer;

public class Config
{
    public static IEnumerable<Client> Clients
        => new Client[]
        {
            // Create new client that request to reach protected Movies api resources 
            new Client()
            {
                ClientId ="movieClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes =
                {
                    "movieAPI"
                }
            }

        };

    public static IEnumerable<ApiScope> ApiScopes
        => new ApiScope[]
        {
            // Protect Movies.Api
            new ApiScope("movieAPI","Movie API")

        };

    public static IEnumerable<ApiResource> apiResources
        => new ApiResource[]
        {

        };
    public static IEnumerable<IdentityResource> IdentityResources
        => new IdentityResource[]
        {


        };

    public static List<TestUser> TestUsers
        => new List<TestUser>()
        {

        };

}
