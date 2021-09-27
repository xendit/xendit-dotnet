namespace Xendit.net.Model.Invoice
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class AvailableRetailOutletInvoice
    {
        [JsonPropertyName("payment_code")]
        public string PaymentCode { get; set; }

        [JsonPropertyName("retail_outlet_name")]
        public RetailOutlet RetailOutletName { get; set; }

        [JsonPropertyName("transfer_amount")]
        public long TransferAmount { get; set; }
    }
}
