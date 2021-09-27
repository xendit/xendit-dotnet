namespace Xendit.net.Model.PaymentMethod
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class PaymentMethodProperties
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("channel_code")]
        public PaymentMethodEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("card_last_four")]
        public string CardLastFour { get; set; }

        [JsonPropertyName("card_expiry")]
        public string CardExpiry { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("account_mobile_number")]
        public string AccountMobileNumber { get; set; }

        [JsonPropertyName("account_details")]
        public string AccountDetails { get; set; }

        [JsonPropertyName("account_hash")]
        public string AccountHash { get; set; }

        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }
    }
}
