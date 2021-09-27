namespace Xendit.net.Model.PaymentMethod
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class PaymentMethodResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public PaymentMethodEnum.AccountType Type { get; set; }

        [JsonPropertyName("properties")]
        public PaymentMethodProperties Properties { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("status")]
        public PaymentMethodEnum.Status Status { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
