namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class AvailableBank
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("can_disburse")]
        public bool CanDisburse { get; set; }

        [JsonPropertyName("can_name_validate")]
        public bool CanNameValidate { get; set; }
    }
}
