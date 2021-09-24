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
            this.Customer = new CustomerClient(apiKey, requestClient, baseUrl);
            this.DirectDebitPayment = new DirectDebitPaymentClient(apiKey, requestClient, baseUrl);
            this.Disbursement = new DisbursementClient(apiKey, requestClient, baseUrl);
            this.EWalletCharge = new EWalletChargeClient(apiKey, requestClient, baseUrl);
            this.EWalletPayment = new EWalletPaymentClient(apiKey, requestClient, baseUrl);
            this.Invoice = new InvoiceClient(apiKey, requestClient, baseUrl);
            this.LinkedAccountToken = new LinkedAccountTokenClient(apiKey, requestClient, baseUrl);
            this.PaymentMethod = new PaymentMethodClient(apiKey, requestClient, baseUrl);
            this.RetailOutlet = new RetailOutletClient(apiKey, requestClient, baseUrl);
            this.VirtualAccount = new VirtualAccountClient(apiKey, requestClient, baseUrl);
            this.VirtualAccountPayment = new VirtualAccountPaymentClient(apiKey, requestClient, baseUrl);
        }

        public BalanceClient Balance { get; private set; }

        public CustomerClient Customer { get; private set; }

        public DirectDebitPaymentClient DirectDebitPayment { get; private set; }

        public DisbursementClient Disbursement { get; private set; }

        public EWalletChargeClient EWalletCharge { get; private set; }

        public EWalletPaymentClient EWalletPayment { get; private set; }

        public InvoiceClient Invoice { get; private set; }

        public LinkedAccountTokenClient LinkedAccountToken { get; private set; }

        public PaymentMethodClient PaymentMethod { get; private set; }

        public RetailOutletClient RetailOutlet { get; private set; }

        public VirtualAccountClient VirtualAccount { get; private set; }

        public VirtualAccountPaymentClient VirtualAccountPayment { get; private set; }

        public void SetApiKey(string apiKey)
        {
            this.Balance.ApiKey = apiKey;
            this.Customer.ApiKey = apiKey;
            this.DirectDebitPayment.ApiKey = apiKey;
            this.Disbursement.ApiKey = apiKey;
            this.EWalletCharge.ApiKey = apiKey;
            this.EWalletPayment.ApiKey = apiKey;
            this.Invoice.ApiKey = apiKey;
            this.LinkedAccountToken.ApiKey = apiKey;
            this.PaymentMethod.ApiKey = apiKey;
            this.RetailOutlet.ApiKey = apiKey;
            this.VirtualAccount.ApiKey = apiKey;
            this.VirtualAccountPayment.ApiKey = apiKey;
        }

        public void SetRequestClient(INetworkClient requestClient)
        {
            this.Balance.RequestClient = requestClient;
            this.Customer.RequestClient = requestClient;
            this.DirectDebitPayment.RequestClient = requestClient;
            this.Disbursement.RequestClient = requestClient;
            this.EWalletCharge.RequestClient = requestClient;
            this.EWalletPayment.RequestClient = requestClient;
            this.Invoice.RequestClient = requestClient;
            this.LinkedAccountToken.RequestClient = requestClient;
            this.PaymentMethod.RequestClient = requestClient;
            this.RetailOutlet.RequestClient = requestClient;
            this.VirtualAccount.RequestClient = requestClient;
            this.VirtualAccountPayment.RequestClient = requestClient;
        }

        public void SetBaseUrl(string baseUrl)
        {
            this.Balance.BaseUrl = baseUrl;
            this.Customer.BaseUrl = baseUrl;
            this.DirectDebitPayment.BaseUrl = baseUrl;
            this.Disbursement.BaseUrl = baseUrl;
            this.EWalletCharge.BaseUrl = baseUrl;
            this.EWalletPayment.BaseUrl = baseUrl;
            this.Invoice.BaseUrl = baseUrl;
            this.LinkedAccountToken.BaseUrl = baseUrl;
            this.PaymentMethod.BaseUrl = baseUrl;
            this.RetailOutlet.BaseUrl = baseUrl;
            this.VirtualAccount.BaseUrl = baseUrl;
            this.VirtualAccountPayment.BaseUrl = baseUrl;
        }
    }
}
