namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model.LinkedAccountToken;

    public struct InitializedLinkedAccountTokenParameter
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("properties")]
        public LinkedAccountTokenProperties Properties { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
