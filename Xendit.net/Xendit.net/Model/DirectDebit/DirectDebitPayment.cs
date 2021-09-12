namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class DirectDebitPayment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public DirectDebitStatus Status { get; set; }

        [JsonPropertyName("failure_code")]
        public string FailureCode { get; set; }

        [JsonPropertyName("is_otp_required")]
        public bool IsOtpRequired { get; set; }

        [JsonPropertyName("otp_mobile_number")]
        public string OtpMobileNumber { get; set; }

        [JsonPropertyName("otp_expiration_timestamp")]
        public string OtpExpirationTimestamp { get; set; }

        [JsonPropertyName("required_action")]
        public DirectDebitRequiredAction RequiredAction { get; set; }

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
        public BasketItem[] Basket { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Create direct debit payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DirectDebitPaymentParameter"/>.</param>
        /// <param name="idempotencyKey">Key provided by the merchant to prevent duplicate requests.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <seealso href="https://developers.xendit.co/api-reference/#create-direct-debit-payment"/>.</param>
        /// <returns>A Task of Direct Debit Payment model <seealso cref="DirectDebitPayment"/>.</returns>
        public static async Task<DirectDebitPayment> Create(DirectDebitPaymentParameter parameter, string idempotencyKey, HeaderParameter? headers = null)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.Idempotencykey = idempotencyKey;
            return await CreateRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Validate OTP for direct debit payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="ValidateDirectDebitPaymentParameter"/>.</param>
        /// <param name="directDebitId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-direct-debit-payment"/>.</param>
        /// <returns>A Task of Direct Debit Payment model <seealso cref="DirectDebitPayment"/>.</returns>
        public static async Task<DirectDebitPayment> ValidateOtp(ValidateDirectDebitPaymentParameter parameter, string directDebitId, HeaderParameter? headers = null)
        {
            return await ValidateOtpRequest(parameter, directDebitId, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by Xendit transaction ID.
        /// </summary>
        /// <param name="id">Xendit identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <seealso href="https://developers.xendit.co/api-reference/#get-payment-by-id"/>.</param>
        /// <returns>A Task of Direct Debit Payment model <seealso cref="DirectDebitPayment"/>.</returns>
        public static async Task<DirectDebitPayment> GetById(string id, HeaderParameter? headers = null)
        {
            return await GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by merchant provided transaction ID.
        /// </summary>
        /// <param name="referenceId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <seealso href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of Direct Debit Payment model <seealso cref="DirectDebitPayment"/>.</returns>
        public static async Task<DirectDebitPayment[]> GetByReferenceId(string referenceId, HeaderParameter? headers = null)
        {
            return await GetByReferenceIdRequest(referenceId, headers);
        }

        private static async Task<DirectDebitPayment> CreateRequest(DirectDebitPaymentParameter parameter, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/direct_debits");
            return await XenditConfiguration.RequestClient.Request<DirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<DirectDebitPayment> ValidateOtpRequest(ValidateDirectDebitPaymentParameter parameter, string directDebitId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/direct_debits/", directDebitId, "/validate_otp/");
            return await XenditConfiguration.RequestClient.Request<ValidateDirectDebitPaymentParameter, DirectDebitPayment>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<DirectDebitPayment> GetByIdRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/direct_debits/", id, "/");
            return await XenditConfiguration.RequestClient.Request<DirectDebitPayment>(HttpMethod.Get, headers, url);
        }

        private static async Task<DirectDebitPayment[]> GetByReferenceIdRequest(string referenceId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/direct_debits?reference_id=", referenceId);
            return await XenditConfiguration.RequestClient.Request<DirectDebitPayment[]>(HttpMethod.Get, headers, url);
        }
    }
}
