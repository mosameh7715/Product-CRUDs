using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

namespace Identity_Server
{
    public static class IdentityServerConfiguration
    {

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("userApi")
                {
                    Scopes = new List<string>{ "user.read", "user.write", "shared" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                },
                new ApiResource("orderApi")
                {
                    Scopes = new List<string>{ "order.read", "order.write", "shared"},
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                },
                new ApiResource("productApi")
                {
                    Scopes = new List<string>{ "product.read", "product.write", "shared"},
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("user.read", "Read Access in User API"),
            new ApiScope("user.write", "Write Access in User API"),

            new ApiScope("order.read", "Read Access in Order API"),
            new ApiScope("order.write", "Write Access in Order API"),

            new ApiScope("product.read", "Read Access in Product API"),
            new ApiScope("product.write", "Write Access in Product API"),

            new ApiScope("shared", "Shared Scope")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "FullAccessClient",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    // scopes that client has access to
                    AllowedScopes = { "user.read","user.write","order.read","order.write","product.read","product.write","shared" }
                }
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "00000000-0000-0000-0000-000000000001",
                    Username = "AhmedTurky",
                    Password = "123456"
                }
            };
    }

}
