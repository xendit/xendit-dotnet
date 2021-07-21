namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class AvailableBank
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
