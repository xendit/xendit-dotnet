namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class DirectDebitRefunds
    {
        [JsonPropertyName("data")]
        public string[] Data { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
