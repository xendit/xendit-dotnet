namespace Xendit.net.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Xendit.net.Exception;

    public class NetworkClient : INetworkClient
    {
        private readonly HttpClient client;

        public NetworkClient(HttpClient httpClient)
        {
            this.client = httpClient;
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.DefaultRequestHeaders.ConnectionClose = true;
        }

        public async Task<T> Request<T>(HttpMethod httpMethod, Dictionary<string, string> headers, string url, Dictionary<string, object> requestBody)
        {
            var request = this.CreateRequestMessage(httpMethod, headers, url, requestBody);
            var response = await this.client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStreamAsync();

            var deserializedResponse = await JsonSerializer.DeserializeAsync<T>(responseBody);
            return deserializedResponse;
        }

        private void CheckApiKey(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new AuthException("No API key is provided yet");
            }
        }

        private string EncodeToBase64String(string apiKey)
        {
            var user = string.Format("{0}", apiKey);
            var password = string.Empty;
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));

            return base64String;
        }

        private HttpRequestMessage CreateRequestMessage(HttpMethod httpMethod, Dictionary<string, string> headers, string url, Dictionary<string, object> requestBody)
        {
            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(url),
            };

            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Patch)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            }

            this.CheckApiKey(XenditConfiguration.ApiKey);
            string apiKeyBase64 = this.EncodeToBase64String(XenditConfiguration.ApiKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", apiKeyBase64);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return request;
        }
    }
}
