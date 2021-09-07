namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public struct UpdateRetailOutletParameter
    {
        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
