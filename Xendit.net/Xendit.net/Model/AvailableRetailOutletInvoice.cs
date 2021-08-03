namespace Xendit.net.Model
{
    using System.Numerics;
    using System.Text.Json.Serialization;

    public class AvailableRetailOutletInvoice
    {
        [JsonPropertyName("payment_code")]
        public string PaymentCode { get; set; }

        [JsonPropertyName("retail_outlet_name")]
        public string RetailOutletName { get; set; }

        [JsonPropertyName("transfer_amount")]
        public BigInteger TransferAmount { get; set; }
    }
}
