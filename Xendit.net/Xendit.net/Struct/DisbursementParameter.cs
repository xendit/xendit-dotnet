namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public struct DisbursementParameter
    {
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("email_to")]
        public string[] EmailTo { get; set; }

        [JsonPropertyName("email_cc")]
        public string[] EmailCc { get; set; }

        [JsonPropertyName("email_bcc")]
        public string[] EmailBcc { get; set; }
    }
}
