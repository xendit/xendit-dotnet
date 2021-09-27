namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Model.Customer;
    using Xendit.net.Model.Invoice;

    public struct InvoiceParameter
    {
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("payer_email")]
        public string PayerEmail { get; set; }

        [JsonPropertyName("should_send_email")]
        public bool? ShouldSendEmail { get; set; }

        [JsonPropertyName("customer_notification")]
        public Dictionary<string, NotificationType[]> CustomerNotification { get; set; }

        [JsonPropertyName("invoice_duration")]
        public int? InvoiceDuration { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("payment_methods")]
        public InvoicePaymentChannelType[] PaymentMethods { get; set; }

        [JsonPropertyName("currency")]
        public Currency? Currency { get; set; }

        [JsonPropertyName("fixed_va")]
        public bool? FixedVa { get; set; }

        [JsonPropertyName("callback_virtual_account_id")]
        public string CallbackVirtualAccountId { get; set; }

        [JsonPropertyName("mid_label")]
        public string MidLabel { get; set; }

        [JsonPropertyName("reminder_time_unit")]
        public string ReminderTimeUnit { get; set; }

        [JsonPropertyName("reminder_time")]
        public int? ReminderTime { get; set; }

        [JsonPropertyName("invoice")]
        public ItemInvoice[] Items { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("fees")]
        public FeeInvoice[] Fees { get; set; }

        [JsonPropertyName("customer_notification_preference")]
        public NotificationPreference NotificationPreference { get; set; }
    }
}
