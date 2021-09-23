namespace Xendit.net.Model.EWallet
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class EWalletChargeResponse
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
        public EWalletChargeProperties ChannelProperties { get; set; }

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
        public Actions Actions { get; set; }

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
    }
}
