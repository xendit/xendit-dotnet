using Xendit.net.Network;

namespace Xendit.net
{
    public class XenditConfiguration
    {
        public static readonly string LiveUrl = "https://api.xendit.co";

        private static volatile string apiUrl = LiveUrl;

        public static string ApiUrl
        {
            get
            {
                return apiUrl;
            }
        }

        public static volatile string ApiKey;

        public static volatile NetworkClient RequestClient;
    }
}
