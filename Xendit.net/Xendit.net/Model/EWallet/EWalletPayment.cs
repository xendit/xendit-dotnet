namespace Xendit.net.Model.EWallet
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class EWalletPayment
    {
        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("transaction_date")]
        public string TransactionDate { get; set; }

        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("ewallet_transaction_id")]
        public string EWalletTransactionId { get; set; }

        [JsonPropertyName("status")]
        public EWalletEnum.Status Status { get; set; }

        [JsonPropertyName("ewallet_type")]
        public EWalletEnum.PaymentType EWalletType { get; set; }

        /// <summary>
        /// Create new e-wallet payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletPaymentParameter"/>. </param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/create-payment"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletPayment"/>.</returns>
        public static async Task<EWalletPayment> Create(EWalletPaymentParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20200201)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await CreateRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Get payment status of an single payment.
        /// </summary>
        /// <param name="externalId">Merchant provided unique ID.</param>
        /// <param name="ewalletType">Type of E-Wallet payment. Use values listed on <see cref="EWalletEnum.PaymentType"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/get-payment-status"/>.</param>
        /// <returns>A Task of <see cref="EWalletPayment"/>.</returns>
        public static async Task<EWalletPayment> Get(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers = null)
        {
            return await GetRequest(externalId, ewalletType, headers);
        }

        private static async Task<EWalletPayment> CreateRequest(EWalletPaymentParameter parameter, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/ewallets");
            return await XenditConfiguration.RequestClient.Request<EWalletPaymentParameter, EWalletPayment>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<EWalletPayment> GetRequest(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers)
        {
            string ewalletTypeString = JsonSerializer.Deserialize<string>(JsonSerializer.Serialize(ewalletType));
            string url = string.Format("{0}/ewallets?external_id={1}&ewallet_type={2}", XenditConfiguration.ApiUrl, externalId, ewalletTypeString);
            return await XenditConfiguration.RequestClient.Request<EWalletPayment>(HttpMethod.Get, headers, url);
        }
    }
}
