namespace Xendit.net.Model.DirectDebit
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class DirectDebitPaymentResponse
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
    }
}
