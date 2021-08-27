namespace Xendit.net.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;

    public class CustomerNotificationPreferenceInvoice
    {
        [JsonPropertyName("invoice_created")]
        public NotificationType[] InvoiceCreated { get; set; }

        [JsonPropertyName("invoice_reminder")]
        public NotificationType[] InvoiceReminder { get; set; }

        [JsonPropertyName("invoice_paid")]
        public NotificationType[] InvoicePaid { get; set; }

        [JsonPropertyName("invoice_expired")]
        public NotificationType[] InvoiceExpired { get; set; }
    }
}
