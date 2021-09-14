namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public struct CreateVirtualAccountParameter
    {
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("virtual_account_number")]
        public string VirtualAccountNumber { get; set; }

        [JsonPropertyName("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonPropertyName("is_closed")]
        public bool IsClosed { get; set; }

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
