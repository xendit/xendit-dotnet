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

        public void CheckApiKey()
        {
            if (string.IsNullOrWhiteSpace(XenditConfiguration.ApiKey))
            {
                throw new AuthException("No API key is provided yet");
            }
        }

        public void SetAuthenticationHeader()
        {
            var user = string.Format("{0}", XenditConfiguration.ApiKey);
            var password = "";
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
        }

        public void setHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public Task<Stream> Request(Dictionary<string, string> headers, string url)
        {
            CheckApiKey();
            SetAuthenticationHeader();
            setHeaders(headers);

            var result = client.GetStreamAsync(url);

            return result;
        }
    }
}
