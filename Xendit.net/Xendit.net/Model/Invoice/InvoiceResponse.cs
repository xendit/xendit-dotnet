namespace Xendit.net.Model.Invoice
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model.Customer;

    public class InvoiceResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("status")]
        public InvoiceStatus Status { get; set; }

        [JsonPropertyName("merchant_name")]
        public string MerchantName { get; set; }

        [JsonPropertyName("merchant_profile_picture_url")]
        public string MerchantProfilePictureUrl { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("payer_email")]
        public string PayerEmail { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }

        [JsonPropertyName("expiry_date")]
        public string ExpiryDate { get; set; }

        [JsonPropertyName("available_banks")]
        public AvailableBankInvoice[] AvailableBanks { get; set; }

        [JsonPropertyName("available_retail_outlets")]
        public AvailableRetailOutletInvoice[] AvailableRetailOutlets { get; set; }

        [JsonPropertyName("available_ewallets")]
        public AvailableEwalletInvoice[] AvailableEwallets { get; set; }

        [JsonPropertyName("should_exclude_credit_card")]
        public bool ShouldExcludeCreditCard { get; set; }

        [JsonPropertyName("should_send_email")]
        public bool ShouldSendEmail { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("mid_label")]
        public string MidLabel { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("paid_at")]
        public string PaidAt { get; set; }

        [JsonPropertyName("credit_card_charge_id")]
        public string CreditCardChargeId { get; set; }

        [JsonPropertyName("payment_method")]
        public InvoicePaymentMethodType PaymentMethod { get; set; }

        [JsonPropertyName("payment_channel")]
        public InvoicePaymentChannelType PaymentChannel { get; set; }

        [JsonPropertyName("payment_destination")]
        public string PaymentDestination { get; set; }

        [JsonPropertyName("fixed_va")]
        public bool FixedVa { get; set; }

        [JsonPropertyName("reminder_date")]
        public string ReminderDate { get; set; }

        [JsonPropertyName("items")]
        public ItemInvoice[] Items { get; set; }

        [JsonPropertyName("fees")]
        public FeeInvoice[] Fees { get; set; }

        [JsonPropertyName("customer_notification_preference")]
        public NotificationPreference NotificationPreference { get; set; }

        [JsonPropertyName("customer")]
        public CustomerResponse Customer { get; set; }
    }
}
