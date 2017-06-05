using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientExample.Helpers
{
    public static class HttpListenerHelpers
    {
        public static HttpListener HttpListener { get; } = new HttpListener();

        public static void StartHttpListener(string redirectUri)
        {
            Console.WriteLine("Listening..");
            HttpListener.Prefixes.Add(redirectUri);
            HttpListener.Start();
        }

        public static void StopHttpListener()
        {
            HttpListener.Stop();
        }

        public static async Task SendHttpResponseToBrowser(HttpListenerContext context)
        {
            var response = context.Response;
            string responseString = "<html><head><meta http-equiv=\'refresh\' content=\'10;url=https://demo.identityserver.io\'></head><body>Please return to the app.</body></html>";
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            await responseOutput.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            responseOutput.Close();
        }

        public static string GetRequestPostData(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                return null;
            }

            using (var body = request.InputStream)
            {
                using (var reader = new System.IO.StreamReader(body, request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
