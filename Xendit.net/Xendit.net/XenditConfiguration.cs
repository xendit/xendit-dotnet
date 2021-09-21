namespace Xendit.net
{
    using Xendit.net.Network;

    public class XenditConfiguration
    {
        public static volatile INetworkClient RequestClient;

        public static string ApiKey { get; set; }

        public static string BaseUrl { get; private set; } = "https://api.xendit.co";
    }
}
