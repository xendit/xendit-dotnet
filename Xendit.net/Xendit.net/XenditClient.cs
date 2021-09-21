namespace Xendit.net
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Network;

    public class XenditClient
    {
        private string apiKey;
        private string baseUrl;
        private INetworkClient requestClient;

        public XenditClient(string apiKey, string baseUrl, INetworkClient requestClient)
        {
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;
            this.requestClient = requestClient;
            this.Balance = new BalanceClient(apiKey, baseUrl, requestClient);
        }

        public BalanceClient Balance { get; private set; }
    }
}
