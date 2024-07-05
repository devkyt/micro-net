using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("microNet", "Auction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
           new Client
           {
                ClientId = "indi",
                ClientName = "Indiana",
                AllowedScopes = {"openid", "profile", "microNet"},
                RedirectUris = {""},
                ClientSecrets = new[] {new Secret("SwordFish".Sha256())},
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
           } 
        };
}
