namespace Xendit.net.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Common;
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

        public async Task<TResponse> Request<TBody, TResponse>(HttpMethod httpMethod, Dictionary<string, string> headers, string url, TBody requestBody)
        {
            var request = CreateRequestMessage(httpMethod, headers, url, requestBody);
            var response = await this.client.SendAsync(request);

            try
            {
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStreamAsync();

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter(ScreamingSnakeCaseNamingPolicy.Instance) },
                };

                var deserializedResponse = await JsonSerializer.DeserializeAsync<TResponse>(responseBody, options);
                return deserializedResponse;
            }
            catch (HttpRequestException e)
            {
                throw new ApiException(e.Message, response.StatusCode.ToString());
            }
        }

        private static void CheckApiKey(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new AuthException("No API key is provided yet");
            }
        }

        private static string EncodeToBase64String(string apiKey)
        {
            var user = string.Format("{0}", apiKey);
            var password = string.Empty;
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));

            return base64String;
        }

        private static HttpRequestMessage CreateRequestMessage<TBody>(HttpMethod httpMethod, Dictionary<string, string> headers, string url, TBody requestBody)
        {
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod(httpMethod.ToString()),
                RequestUri = new Uri(url),
            };

            if (httpMethod == HttpMethod.Post || httpMethod == XenditHttpMethod.Patch)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    Converters = { new JsonStringEnumConverter(ScreamingSnakeCaseNamingPolicy.Instance) },
                };

                request.Content = new StringContent(JsonSerializer.Serialize(requestBody, options), Encoding.UTF8, "application/json");
            }

            CheckApiKey(XenditConfiguration.ApiKey);
            string apiKeyBase64 = EncodeToBase64String(XenditConfiguration.ApiKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", apiKeyBase64);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return request;
        }
    }
}
