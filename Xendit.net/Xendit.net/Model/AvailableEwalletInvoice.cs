namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class AvailableEwalletInvoice
    {
        [JsonPropertyName("ewallet_type")]
        public string EwalletType { get; set; }
    }
}
