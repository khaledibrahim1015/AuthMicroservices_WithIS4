﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

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
            },
            new Client
                   {
                       ClientId = "movies_mvc_client",
                       ClientName = "Movies MVC Web App",
                       AllowedGrantTypes = GrantTypes.Code,
                       RequirePkce = false,
                       AllowRememberConsent = false,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,

                       }
                   }

        };

    public static IEnumerable<ApiScope> ApiScopes
        => new ApiScope[]
        {
            // Protect Movies.Api
            new ApiScope("movieAPI","Movie API")

        };

    public static IEnumerable<ApiResource> ApiResources
        => new ApiResource[]
        {

        };
    public static IEnumerable<IdentityResource> IdentityResources
        => new IdentityResource[]
        {
                new IdentityResources.OpenId(),
               new IdentityResources.Profile(),

        };

    public static List<TestUser> TestUsers
        => new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "khaled",
                    Password = "asd",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "khaled"),
                        new Claim(JwtClaimTypes.FamilyName, "ibrahim")
                    }
                }
            };

}
