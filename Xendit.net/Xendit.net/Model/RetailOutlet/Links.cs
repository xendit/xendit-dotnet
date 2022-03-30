namespace Xendit.net.Model.RetailOutlet
{
    using System.Text.Json.Serialization;

    public class Links {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("rel")]
        public string Rel { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }
    }
}
