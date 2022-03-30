namespace Xendit.net.Model.RetailOutlet
{
    using System.Text.Json.Serialization;

    public class Payment
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("fixed_payment_code_payment_id")]
        public string FixedPaymentCodePaymentId { get; set; }

        [JsonPropertyName("fixed_payment_code_id")]
        public string FixedPaymentCodeId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("payment_code")]
        public string PaymentCode { get; set; }

        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("retail_outlet_name")]
        public string RetailOutletName { get; set; }

        [JsonPropertyName("transaction_timestamp")]
        public string TransactionTimestamp { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }
    }
}
