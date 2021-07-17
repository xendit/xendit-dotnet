namespace Xendit.net
{
    using Xendit.net.Network;

    public class XenditConfiguration
    {
        public static readonly string LiveUrl = "https://api.xendit.co";

        public static volatile string ApiKey;

        public static volatile INetworkClient RequestClient;

        private static volatile string apiUrl = LiveUrl;

        public static string ApiUrl
        {
            get
            {
                return apiUrl;
            }
        }
    }
}
