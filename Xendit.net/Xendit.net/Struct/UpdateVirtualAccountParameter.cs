namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public struct UpdateVirtualAccountParameter
    {
        [JsonPropertyName("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonPropertyName("expected_amount")]
        public long ExpectedAmount { get; set; }

        [JsonPropertyName("suggested_amount")]
        public long SuggestedAmount { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
