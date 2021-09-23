namespace Xendit.net.Model
{
    using Xendit.net.Network;

    public class BaseClient
    {
        protected string apiKey;
        protected string baseUrl;
        protected INetworkClient requestClient;

        public BaseClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
        {
            this.apiKey = apiKey;
            this.requestClient = requestClient;
            this.baseUrl = baseUrl;
        }

        public string ApiKey
        {
            get => this.apiKey;
            set => this.apiKey = value;
        }

        public INetworkClient RequestClient
        {
            get => this.requestClient;
            set => this.requestClient = value;
        }

        public string BaseUrl
        {
            get => this.baseUrl;
            set => this.baseUrl = value;
        }
    }
}
