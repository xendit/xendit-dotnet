namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class EWalletCharge
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("checkout_method")]
        public string CheckoutMethod { get; set; }

        [JsonPropertyName("channel_code")]
        public string ChannelCode { get; set; }

        [JsonPropertyName("channel_properties")]
        public Dictionary<string, string> ChannelProperties { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("basket")]
        public EWalletBasketItem[] Basket { get; set; }

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
        /// Create new e-wallet charge with all parameters.
        /// </summary>
        /// <param name="referenceId">Reference ID provided by merchant.</param>
        /// <param name="currency">Currency used for the transaction in ISO4217 format.</param>
        /// <param name="amount">Transaction amount to be paid.</param>
        /// <param name="checkoutMethod">Checkout method determines the payment flow used to process the transaction.</param>
        /// <param name="channelCode">Channel Code specifies which eWallet will be used to process the transaction.</param>
        /// <param name="channelProperties">Channel specific information required for the transaction to be initiated.</param>
        /// <param name="paymentMethodId">ID of the payment method.</param>
        /// <param name="customerId">ID of the customer object to which the payment method will be linked to.</param>
        /// <param name="basket">Array of objects describing the item(s) purchased.</param>
        /// <param name="metadata">Object of additional information the user may use.</param>
        /// <returns>A Task of E-Wallet Charge model.</returns>
        public static async Task<EWalletCharge> Create(string referenceId, string currency, long amount, string checkoutMethod, string channelCode, Dictionary<string, string> channelProperties, string paymentMethodId, string customerId, EWalletBasketItem[] basket, Dictionary<string, object> metadata)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("reference_id", referenceId);
            parameter.Add("currency", currency);
            parameter.Add("amount", amount);
            parameter.Add("checkout_method", checkoutMethod);
            parameter.Add("channel_code", channelCode);
            parameter.Add("channel_properties", channelProperties);
            parameter.Add("payment_method_id", paymentMethodId);
            parameter.Add("customer_id", customerId);
            parameter.Add("basket", basket);
            parameter.Add("metadata", metadata);

            return await CreateChargeRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create new e-wallet charge with all parameters and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g. "for-user-id".</param>
        /// <param name="referenceId">Reference ID provided by merchant.</param>
        /// <param name="currency">Currency used for the transaction in ISO4217 format.</param>
        /// <param name="amount">Transaction amount to be paid.</param>
        /// <param name="checkoutMethod">Checkout method determines the payment flow used to process the transaction.</param>
        /// <param name="channelCode">Channel Code specifies which eWallet will be used to process the transaction.</param>
        /// <param name="channelProperties">Channel specific information required for the transaction to be initiated.</param>
        /// <param name="paymentMethodId">ID of the payment method.</param>
        /// <param name="customerId">ID of the customer object to which the payment method will be linked to.</param>
        /// <param name="basket">Array of objects describing the item(s) purchased.</param>
        /// <param name="metadata">Object of additional information the user may use.</param>
        /// <returns>A Task of E-Wallet Charge model.</returns>
        public static async Task<EWalletCharge> Create(Dictionary<string, string> headers, string referenceId, string currency, long amount, string checkoutMethod, string channelCode, Dictionary<string, string> channelProperties, string paymentMethodId, string customerId, EWalletBasketItem[] basket, Dictionary<string, object> metadata)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("reference_id", referenceId);
            parameter.Add("currency", currency);
            parameter.Add("amount", amount);
            parameter.Add("checkout_method", checkoutMethod);
            parameter.Add("channel_code", channelCode);
            parameter.Add("channel_properties", channelProperties);
            parameter.Add("payment_method_id", paymentMethodId);
            parameter.Add("customer_id", customerId);
            parameter.Add("basket", basket);
            parameter.Add("metadata", metadata);

            return await CreateChargeRequest(headers, parameter);
        }

        /// <summary>
        /// Create new e-wallet charge with all parameter as Dictionary.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-ewallet-charge.</param>
        /// <returns>A Task of E-Wallet Charge model.</returns>
        public static async Task<EWalletCharge> Create(Dictionary<string, object> parameter)
        {
            return await CreateChargeRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create new e-wallet charge with all parameter as Dictionary and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g. "for-user-id".</param>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-ewallet-charge.</param>
        /// <returns>A Task of E-Wallet Charge model.</returns>
        public static async Task<EWalletCharge> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return await CreateChargeRequest(headers, parameter);
        }

        /// <summary>
        /// Get e-Wallet charge by id.
        /// </summary>
        /// <param name="chargeId">E-Wallet charge ID.</param>
        /// <returns>A Task of E-Wallet Charge model.</returns>
        public static async Task<EWalletCharge> Get(string chargeId)
        {
            return await GetChargeRequest(new Dictionary<string, string>(), chargeId);
        }

        /// <summary>
        /// Get e-Wallet charge by id with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g. "for-user-id".</param>
        /// <param name="chargeId">E-Wallet charge ID.</param>
        /// <returns>A Task of E-Wallet Charge model</returns>
        public static async Task<EWalletCharge> Get(Dictionary<string, string> headers, string chargeId)
        {
            return await GetChargeRequest(headers, chargeId);
        }

        private static async Task<EWalletCharge> CreateChargeRequest(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/ewallets/charges");
            return await XenditConfiguration.RequestClient.Request<EWalletCharge>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<EWalletCharge> GetChargeRequest(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/ewallets/charges/", id);
            return await XenditConfiguration.RequestClient.Request<EWalletCharge>(HttpMethod.Get, headers, url, null);
        }
    }
}
