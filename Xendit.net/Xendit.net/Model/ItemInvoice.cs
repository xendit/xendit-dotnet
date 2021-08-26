namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class ItemInvoice
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("Quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("Price")]
        public long Price { get; set; }
    }
}
