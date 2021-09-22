namespace Xendit.net
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Model.Disbursement;
    using Xendit.net.Model.VirtualAccount;
    using Xendit.net.Network;

    public class XenditClient
    {
        public XenditClient(string apiKey, INetworkClient requestClient, string baseUrl = "https://api.xendit.co")
        {
            this.Balance = new BalanceClient(apiKey, requestClient, baseUrl);
            this.VirtualAccount = new VirtualAccountClient(apiKey, requestClient, baseUrl);
            this.VirtualAccountPayment = new VirtualAccountPaymentClient(apiKey, requestClient, baseUrl);
            this.Disbursement = new DisbursementClient(apiKey, requestClient, baseUrl);
        }

        public BalanceClient Balance { get; private set; }

        public VirtualAccountClient VirtualAccount { get; private set; }

        public VirtualAccountPaymentClient VirtualAccountPayment { get; private set; }

        public DisbursementClient Disbursement { get; private set; }
    }
}
