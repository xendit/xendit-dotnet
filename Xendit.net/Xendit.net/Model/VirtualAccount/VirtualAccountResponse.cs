namespace Xendit.net.Model.VirtualAccount
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class VirtualAccountResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("bank_code")]
        public VirtualAccountEnum.BankCode BankCode { get; set; }

        [JsonPropertyName("merchant_code")]
        public string MerchantCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("is_closed")]
        public bool IsClosed { get; set; }

        [JsonPropertyName("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonPropertyName("status")]
        public VirtualAccountEnum.Status Status { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("expected_amount")]
        public long ExpectedAmount { get; set; }

        [JsonPropertyName("suggested_amount")]
        public long SuggestedAmount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
