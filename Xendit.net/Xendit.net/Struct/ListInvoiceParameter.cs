namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public struct ListInvoiceParameter
    {
        [JsonPropertyName("statuses")]
        public InvoiceStatus[] Statuses { get; set; }

        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("created_after")]
        public string CreatedAfter { get; set; }

        [JsonPropertyName("created_before")]
        public string CreatedBefore { get; set; }

        [JsonPropertyName("paid_after")]
        public string PaidAfter { get; set; }

        [JsonPropertyName("paid_before")]
        public string PaidBefore { get; set; }

        [JsonPropertyName("expired_after")]
        public string ExpiredAfter { get; set; }

        [JsonPropertyName("expired_before")]
        public string ExpiredBefore { get; set; }

        [JsonPropertyName("last_invoice_id")]
        public string LastInvoiceId { get; set; }

        [JsonPropertyName("client_types")]
        public InvoiceClientType[] ClientTypes { get; set; }

        [JsonPropertyName("payment_channels")]
        public InvoicePaymentChannelType[] PaymentChannels { get; set; }

        [JsonPropertyName("on_demand_link")]
        public string OnDemandLink { get; set; }

        [JsonPropertyName("recurring_payment_id")]
        public string RecurringPaymentId { get; set; }
    }
}
