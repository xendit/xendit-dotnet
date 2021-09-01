namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class FeeInvoice
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}
