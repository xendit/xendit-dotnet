namespace Xendit.net.Model.Invoice
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class NotificationPreference
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
