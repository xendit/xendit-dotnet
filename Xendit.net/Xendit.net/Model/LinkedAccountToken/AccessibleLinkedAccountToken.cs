namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class AccessibleLinkedAccountToken
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("type")]
        public LinkedAccountEnum.Type Type { get; set; }

        [JsonPropertyName("properties")]
        public LinkedAccountTokenProperties Properties { get; set; }
    }
}
