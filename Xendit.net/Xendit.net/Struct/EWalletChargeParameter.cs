namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model.EWallet;

    public struct EWalletChargeParameter
    {
        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("checkout_method")]
        public EWalletEnum.CheckoutMethod? CheckoutMethod { get; set; }

        [JsonPropertyName("channel_code")]
        public EWalletEnum.ChannelCode? ChannelCode { get; set; }

        [JsonPropertyName("channel_properties")]
        public EWalletChargeProperties ChannelProperties { get; set; }

        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("basket")]
        public BasketItem[] Basket { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
