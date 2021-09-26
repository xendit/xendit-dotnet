namespace Xendit.net.Model.Customer
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class IdentityAccount
    {
        [JsonPropertyName("country")]
        public Country? Country { get; set; }

        [JsonPropertyName("type")]
        public CustomerIdentityAccountType? Type { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("properties")]
        public IdentityAccountProperties Properties { get; set; }
    }
}
