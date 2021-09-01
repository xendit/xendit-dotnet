namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class ItemInvoice
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        [JsonPropertyName("price")]
        public long Price { get; set; }
    }
}
