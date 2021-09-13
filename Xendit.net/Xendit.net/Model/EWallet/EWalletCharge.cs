namespace Xendit.net.Model.EWallet
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class EWalletCharge
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("status")]
        public EWalletEnum.Status Status { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("checkout_method")]
        public EWalletEnum.CheckoutMethod CheckoutMethod { get; set; }

        [JsonPropertyName("channel_code")]
        public EWalletEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("channel_properties")]
        public Dictionary<string, string> ChannelProperties { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("basket")]
        public BasketItem[] Basket { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonPropertyName("charge_amount")]
        public long ChargeAmount { get; set; }

        [JsonPropertyName("capture_amount")]
        public long CaptureAmount { get; set; }

        [JsonPropertyName("actions")]
        public Dictionary<string, string> Actions { get; set; }

        [JsonPropertyName("is_redirect_required")]
        public bool IsRedirectRequired { get; set; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("voided_at")]
        public string VoidedAt { get; set; }

        [JsonPropertyName("capture_now")]
        public bool CaptureNow { get; set; }

        [JsonPropertyName("failure_code")]
        public string FailureCode { get; set; }

        /// <summary>
        /// Create new e-wallet charge with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletChargeParameter"/>. </param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-ewallet-charge"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of E-Wallet Charge model <seealso cref="EWalletCharge"/>.</returns>
        public static async Task<EWalletCharge> Create(EWalletChargeParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await CreateChargeRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Get e-Wallet charge by id.
        /// </summary>
        /// <param name="chargeId">E-Wallet charge ID.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-ewallet-charge-status"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of E-Wallet Charge model <seealso cref="EWalletCharge"/>.</returns>
        public static async Task<EWalletCharge> Get(string chargeId, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await GetChargeRequest(chargeId, validHeaders);
        }

        private static async Task<EWalletCharge> CreateChargeRequest(EWalletChargeParameter parameter, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/ewallets/charges");
            return await XenditConfiguration.RequestClient.Request<EWalletChargeParameter, EWalletCharge>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<EWalletCharge> GetChargeRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/ewallets/charges/", id);
            return await XenditConfiguration.RequestClient.Request<EWalletCharge>(HttpMethod.Get, headers, url);
        }
    }
}
