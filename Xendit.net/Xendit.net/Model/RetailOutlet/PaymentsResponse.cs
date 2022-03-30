namespace Xendit.net.Model.RetailOutlet
{
    using System.Text.Json.Serialization;

    public class PaymentsResponse
    {
        [JsonPropertyName("data")]
        public Payment[] Data { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }
    }
}
