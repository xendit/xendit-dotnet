namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model.EWallet;

    public struct EWalletPaymentParameter
    {
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("ewallet_type")]
        public EWalletEnum.PaymentType EWalletType { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonPropertyName("Items")]
        public Item[] Items { get; set; }
    }
}
