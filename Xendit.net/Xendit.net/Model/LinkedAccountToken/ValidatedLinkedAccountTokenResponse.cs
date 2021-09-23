namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class ValidatedLinkedAccountTokenResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("status")]
        public LinkedAccountEnum.Status Status { get; set; }
    }
}
