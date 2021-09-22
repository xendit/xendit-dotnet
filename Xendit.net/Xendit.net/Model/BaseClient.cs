namespace Xendit.net.Model
{
    using Xendit.net.Network;

    public class BaseClient
    {
        protected string apiKey;
        protected string baseUrl;
        protected INetworkClient requestClient;

        public BaseClient(string apiKey = null, string baseUrl = null, INetworkClient requestClient = null)
        {
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;
            this.requestClient = requestClient;
        }
    }
}
