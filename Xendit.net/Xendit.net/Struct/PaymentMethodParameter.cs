namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model;

    public struct PaymentMethodParameter
    {
        [JsonPropertyName("type")]
        public PaymentMethodEnum.AccountType Type { get; set; }

        [JsonPropertyName("properties")]
        public PaymentMethodProperties Properties { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
