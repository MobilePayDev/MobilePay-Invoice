using IdentityModel.OidcClient;

namespace ConnectClientExample.Configuration
{
    public class OidcClientConfigurationFactory
    {
        public static OidcClientOptions CreateClientConfiguration(string redirectUri)
        {
            var policy = new Policy {Discovery = {ValidateIssuerName = false, ValidateEndpoints = false}};

            return new OidcClientOptions
            {
                Authority = "https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect",
                ClientId = "<Your-Client-Id",
                ClientSecret = "<Your-Client-Secret>",
                Scope = "openid offline_access invoice subscriptions transactionreporting",
                RedirectUri = redirectUri,
                LoadProfile = false,
                Policy = policy,
                Flow = OidcClientOptions.AuthenticationFlow.Hybrid,
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.FormPost
            };
        }
    }
}
