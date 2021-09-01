namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class Customer
    {
        [JsonPropertyName("given_names")]
        public string GivenNames { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("mobile_number")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }
    }
}
