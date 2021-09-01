namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class IdentityAccountProperties
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; }

        [JsonPropertyName("payment_code")]
        public string PaymentCode { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonPropertyName("qr_string")]
        public string QrString { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("account_handle")]
        public string AccountHandle { get; set; }
    }
}
