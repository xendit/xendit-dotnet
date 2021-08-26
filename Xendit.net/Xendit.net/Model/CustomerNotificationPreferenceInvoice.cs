namespace Xendit.net.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class CustomerNotificationPreferenceInvoice
    {
        [JsonPropertyName("invoice_created")]
        public string[] InvoiceCreated { get; set; }

        [JsonPropertyName("invoice_reminder")]
        public string[] InvoiceReminder { get; set; }

        [JsonPropertyName("invoice_paid")]
        public string[] InvoicePaid { get; set; }

        [JsonPropertyName("invoice_expired")]
        public string[] InvoiceExpired { get; set; }
    }
}
