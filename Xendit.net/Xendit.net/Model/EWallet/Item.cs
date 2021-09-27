namespace Xendit.net.Model.EWallet
{
    using System.Text.Json.Serialization;

    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public long? Price { get; set; }

        [JsonPropertyName("quantity")]
        public long? Quantity { get; set; }
    }
}
