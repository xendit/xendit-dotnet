namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class CustomerIdentityAccount
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
