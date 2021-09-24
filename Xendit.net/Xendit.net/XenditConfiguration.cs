namespace Xendit.net
{
    using System.Net.Http;
    using Xendit.net.Network;

    public class XenditConfiguration
    {

        private static INetworkClient requestClient;

        public static INetworkClient RequestClient
        {
            get
            {
                if (requestClient != null)
                {
                    return requestClient;
                }

                HttpClient httpClient = new HttpClient();
                NetworkClient client = new NetworkClient(httpClient);

                return client;
            }

            set => requestClient = value;
        }

        public static string ApiKey { get; set; }

        public static string BaseUrl { get; private set; } = "https://api.xendit.co";
    }
}
