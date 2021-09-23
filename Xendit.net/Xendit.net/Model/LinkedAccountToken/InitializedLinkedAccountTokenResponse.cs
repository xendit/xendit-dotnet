namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class InitializedLinkedAccountTokenResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("authorizer_url")]
        public string AuthorizerUrl { get; set; }

        [JsonPropertyName("status")]
        public LinkedAccountEnum.Status Status { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
