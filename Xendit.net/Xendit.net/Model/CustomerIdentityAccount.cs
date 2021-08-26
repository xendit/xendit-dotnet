namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class CustomerIdentityAccount
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("type")]
        public CustomerIdentityAccountType Type { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("properties")]
        public CustomerIdentityAccountProperties Properties { get; set; }
    }
}
