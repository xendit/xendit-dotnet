namespace Xendit.net
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Model.Customer;
    using Xendit.net.Model.DirectDebit;
    using Xendit.net.Model.Disbursement;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Model.Invoice;
    using Xendit.net.Model.LinkedAccountToken;
    using Xendit.net.Model.PaymentMethod;
    using Xendit.net.Model.RetailOutlet;
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
            this.Invoice = new InvoiceClient(apiKey, requestClient, baseUrl);
            this.Customer = new CustomerClient(apiKey, requestClient, baseUrl);
            this.RetailOutlet = new RetailOutletClient(apiKey, requestClient, baseUrl);
            this.DirectDebitPayment = new DirectDebitPaymentClient(apiKey, requestClient, baseUrl);
            this.PaymentMethod = new PaymentMethodClient(apiKey, requestClient, baseUrl);
            this.LinkedAccountToken = new LinkedAccountTokenClient(apiKey, requestClient, baseUrl);
            this.EWalletCharge = new EWalletChargeClient(apiKey, requestClient, baseUrl);
            this.EWalletPayment = new EWalletPaymentClient(apiKey, requestClient, baseUrl);
        }

        public BalanceClient Balance { get; private set; }

        public VirtualAccountClient VirtualAccount { get; private set; }

        public VirtualAccountPaymentClient VirtualAccountPayment { get; private set; }

        public DisbursementClient Disbursement { get; private set; }

        public InvoiceClient Invoice { get; private set; }

        public CustomerClient Customer { get; private set; }

        public RetailOutletClient RetailOutlet { get; private set; }

        public DirectDebitPaymentClient DirectDebitPayment { get; private set; }

        public PaymentMethodClient PaymentMethod { get; private set; }

        public LinkedAccountTokenClient LinkedAccountToken { get; private set; }

        public EWalletChargeClient EWalletCharge { get; private set; }

        public EWalletPaymentClient EWalletPayment { get; private set; }
    }
}
