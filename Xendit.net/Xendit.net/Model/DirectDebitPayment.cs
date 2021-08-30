namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class DirectDebitPayment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("channel_code")]
        public string ChannelCode { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("currency")]
        public long Currency { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("failure_code")]
        public string FailureCode { get; set; }

        [JsonPropertyName("is_otp_required")]
        public bool IsOTPRequired { get; set; }

        [JsonPropertyName("otp_mobile_number")]
        public string OTPMobileNumber { get; set; }

        [JsonPropertyName("otp_expiration_timestamp")]
        public string OTPExpirationTimestamp { get; set; }

        [JsonPropertyName("required_action")]
        public string RequiredAction { get; set; }

        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("refunded_amount")]
        public long RefundedAmount { get; set; }

        [JsonPropertyName("refunds")]
        public DirectDebitRefunds Refunds { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("basket")]
        public DirectDebitBasketItem[] Basket { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Create Direct Debit Payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DirectDebitPaymentParameter"/>.</param>
        /// <param name="idempotencyKey">Key provided by the merchant to prevent duplicate requests. </param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#create-direct-debit-payment"/></param>
        /// <returns>A Task of Direct Debit Payment model.</returns>
        public static async Task<DirectDebitPayment> Create(DirectDebitPaymentParameter parameter, string idempotencyKey, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            headers.Add("idempotency-key", idempotencyKey);
            return await CreateRequest(parameter, headers);
        }

        /// <summary>
        /// Validate OTP for direct debit payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="ValidateDirectDebitPaymentParameter"/>.</param>
        /// <param name="directDebitId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#validate-otp-for-direct-debit-payment"/></param>
        /// <returns>A Task of Direct Debit Payment model.</returns>
        public static async Task<DirectDebitPayment> ValidateOTP(ValidateDirectDebitPaymentParameter parameter, string directDebitId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await ValidateOTPRequest(parameter, directDebitId, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by Xendit transaction ID.
        /// </summary>
        /// <param name="id">Xendit identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#get-payment-by-id"/></param>
        /// <returns>A Task of Direct Debit Payment model.</returns>
        public static async Task<DirectDebitPayment> GetById(string id, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by merchant provided transaction ID.
        /// </summary>
        /// <param name="referenceId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/></param>
        /// <returns>A Task of Direct Debit Payment model.</returns>
        public static async Task<DirectDebitPayment[]> GetByReferenceId(string referenceId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetByReferenceIdRequest(referenceId, headers);
        }

        private static async Task<DirectDebitPayment> CreateRequest(DirectDebitPaymentParameter parameter, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/direct_debits");
            return await XenditConfiguration.RequestClient.Request<DirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<DirectDebitPayment> ValidateOTPRequest(ValidateDirectDebitPaymentParameter parameter, string directDebitId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/direct_debits/", directDebitId, "/validate_otp/");
            return await XenditConfiguration.RequestClient.Request<ValidateDirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<DirectDebitPayment> GetByIdRequest(string id, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/direct_debits/", id, "/");
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, DirectDebitPayment>(HttpMethod.Get, headers, url, null);
        }

        private static async Task<DirectDebitPayment[]> GetByReferenceIdRequest(string referenceId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/direct_debits?reference_id=", referenceId);
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, DirectDebitPayment[]>(HttpMethod.Get, headers, url, null);
        }
    }
}
