using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace eCommerce.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("ecommerce", "eCommerce Server"),
                new ApiScope(name: "read", "Read Data."),
                new ApiScope(name: "write", "Write Data."),
                new ApiScope(name: "delete", "Delete Data."),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("TheSuperSecret_SHA".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "ecommerce",
                    ClientSecrets = {new Secret("TheSuperSecret_SHA".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:11539/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:11539/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerce"
                    }
                }
            };
    }
}
