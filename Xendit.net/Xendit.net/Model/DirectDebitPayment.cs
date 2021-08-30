namespace Xendit.net.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

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
        public string Currency { get; set; }

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

        public static async Task<DirectDebitPayment> Create(string idempotencyKey, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            headers.Add("idempotency-key", idempotencyKey);
            return await CreateRequest(headers);
        }

        public static async Task<DirectDebitPayment> GetById(string id, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetByIdRequest(id, headers);
        }

        public static async Task<DirectDebitPayment[]> GetByReferenceId(string referenceId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetByReferenceIdRequest(referenceId, headers);
        }

        private static async Task<DirectDebitPayment> CreateRequest(Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/direct_debits");
            return await XenditConfiguration.RequestClient.Request<DirectDebitPayment>(HttpMethod.Post, headers, url, null);
        }

        private static async Task<DirectDebitPayment> GetByIdRequest(string id, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/direct_debits/", id, "/");
            return await XenditConfiguration.RequestClient.Request<DirectDebitPayment>(HttpMethod.Get, headers, url, null);
        }

        private static async Task<DirectDebitPayment[]> GetByReferenceIdRequest(string referenceId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/direct_debits?reference_id=", referenceId);
            return await XenditConfiguration.RequestClient.Request<DirectDebitPayment[]>(HttpMethod.Get, headers, url, null);
        }
    }
}
