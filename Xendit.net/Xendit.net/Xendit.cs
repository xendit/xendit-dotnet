using System;

namespace xendit.net
{
    public class Xendit
    {
        public static readonly string LiveUrl = "https://api.xendit.co";

        public static volatile string apiKey;

        private static volatile string apiUrl = LiveUrl;

        public static string ApiUrl { get;  }

        public static string ApiKey { get; }
    }
}
