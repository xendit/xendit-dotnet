namespace Xendit.net
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Model.VirtualAccount;
    using Xendit.net.Network;

    public class XenditClient
    {
        public XenditClient(string apiKey, string baseUrl, INetworkClient requestClient)
        {
            this.Balance = new BalanceClient(apiKey, baseUrl, requestClient);
            this.VirtualAccount = new VirtualAccountClient(apiKey, baseUrl, requestClient);
            this.VirtualAccountPayment = new VirtualAccountPaymentClient(apiKey, baseUrl, requestClient);
        }

        public BalanceClient Balance { get; private set; }

        public VirtualAccountClient VirtualAccount { get; private set; }

        public VirtualAccountPaymentClient VirtualAccountPayment { get; private set; }
    }
}
