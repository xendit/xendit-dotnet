using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xendit.net.Exception;

namespace Xendit.net.Network
{
    public class NetworkClient
    {
        private static readonly HttpClient client;
        static NetworkClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.ConnectionClose = true;
        }

        public Task<Stream> Request(Dictionary<string, string> headers, string url)
        {

            if (string.IsNullOrWhiteSpace(XenditConfiguration.ApiKey))
            {
                throw new AuthException("No API key is provided yet");
            }

            var user = string.Format("{0}", XenditConfiguration.ApiKey);
            var password = "";
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);


            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var result = client.GetStreamAsync(url);

            return result;
        }
    }
}
