namespace Xendit.net.Model.Disbursement
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class DisbursementResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("bank_code")]
        public DisbursementChannelCode BankCode { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonPropertyName("disbursement_description")]
        public string DisbursementDescription { get; set; }

        [JsonPropertyName("status")]
        public DisbursementStatus Status { get; set; }

        [JsonPropertyName("email_to")]
        public string[] EmailTo { get; set; }

        [JsonPropertyName("email_cc")]
        public string[] EmailCC { get; set; }

        [JsonPropertyName("email_bcc")]
        public string[] EmailBCC { get; set; }
    }
}
