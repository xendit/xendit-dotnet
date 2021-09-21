namespace Xendit.net
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Model.VirtualAccount;
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
            this.VirtualAccount = new VirtualAccountClient(apiKey, baseUrl, requestClient);
            this.VirtualAccountPayment = new VirtualAccountPaymentClient(apiKey, baseUrl, requestClient);
        }

        public BalanceClient Balance { get; private set; }

        public VirtualAccountClient VirtualAccount { get; private set; }

        public VirtualAccountPaymentClient VirtualAccountPayment { get; private set; }
    }
}
