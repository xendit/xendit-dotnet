namespace Xendit.net
{
    using Xendit.net.Network;

    public class XenditConfiguration
    {
        public static volatile INetworkClient RequestClient;

        private static readonly string LiveUrl = "https://api.xendit.co";
        private static volatile string apiUrl = LiveUrl;

        public static string ApiKey { get; set; }

        public static string ApiUrl
        {
            get
            {
                return apiUrl;
            }
        }
    }
}
