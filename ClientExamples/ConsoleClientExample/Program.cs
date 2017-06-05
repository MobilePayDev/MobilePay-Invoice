using System;
using System.Diagnostics;
using System.Net;
using ConsoleClientExample.Helpers;
using IdentityModel.OidcClient;

namespace ConsoleClientExample
{
    class Program
    {
        // create a redirect URI on the loopback address.
        private static string RedirectUri { get; } = "http://127.0.0.1:7890/"; // TODO: Replace with predefined loopback address/port

        static void Main(string[] args)
        {
            // Make sure that https is working correctly in the example
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 |
                                                   SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls;

            Console.WriteLine("+-----------------------+");
            Console.WriteLine("|  Sign in with OIDC    |");
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("");
            Console.WriteLine("Press any key to sign in...");
            Console.ReadKey();

            HttpListenerHelpers.StartHttpListener(RedirectUri);

            Program p = new Program();
            p.SignIn();

            Console.ReadKey();
            HttpListenerHelpers.StopHttpListener();
        }

        private async void SignIn()
        {
            // Create an oidc client and configure it according to your specific client
            var client = new OidcClient(OidcClientHelpers.ConfigureOidcClient(RedirectUri));

            // Prepare login
            var state = await client.PrepareLoginAsync().ConfigureAwait(false);

            // Open system browser to start authentication
            Process.Start(state.StartUrl);

            // wait for the authorization response.
            var context = await HttpListenerHelpers.HttpListener.GetContextAsync();
            var formData = HttpListenerHelpers.GetRequestPostData(context.Request);

            // Brings the Console to Focus.
            ConsoleHelpers.BringConsoleToFront();

            // Update browser
            await HttpListenerHelpers.SendHttpResponseToBrowser(context);

            // Complete request for access token with authorization code
            var result = await client.ProcessResponseAsync(formData, state).ConfigureAwait(false);

            // Print login result information
            OidcClientHelpers.PrintLoginInformation(result);
        }
    }
}
