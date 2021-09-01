namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class AvailableEwalletInvoice
    {
        [JsonPropertyName("ewallet_type")]
        public EwalletType EwalletType { get; set; }
    }
}
