namespace Xendit.net.Model.EWallet
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class EWalletPaymentClient : BaseClient
    {
        public EWalletPaymentClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create new e-wallet payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletPaymentParameter"/>. </param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/create-payment"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletPaymentResponse"/>.</returns>
        public async Task<EWalletPaymentResponse> Create(EWalletPaymentParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20200201)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await this.CreateRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Get payment status of an single payment.
        /// </summary>
        /// <param name="externalId">Merchant provided unique ID.</param>
        /// <param name="ewalletType">Type of E-Wallet payment. Use values listed on <see cref="EWalletEnum.PaymentType"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/get-payment-status"/>.</param>
        /// <returns>A Task of <see cref="EWalletPaymentResponse"/>.</returns>
        public async Task<EWalletPaymentResponse> Get(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers = null)
        {
            return await this.GetRequest(externalId, ewalletType, headers);
        }

        private async Task<EWalletPaymentResponse> CreateRequest(EWalletPaymentParameter parameter, HeaderParameter? headers)
        {
            string url = "/ewallets";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<EWalletPaymentParameter, EWalletPaymentResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<EWalletPaymentResponse> GetRequest(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers)
        {
            string ewalletTypeString = JsonSerializer.Deserialize<string>(JsonSerializer.Serialize(ewalletType));
            string url = string.Format("/ewallets?external_id={0}&ewallet_type={1}", externalId, ewalletTypeString);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<EWalletPaymentResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
