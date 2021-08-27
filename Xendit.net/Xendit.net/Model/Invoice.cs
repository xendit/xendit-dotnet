namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Common;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Invoice
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
        public bool ReminderDate { get; set; }

        [JsonPropertyName("items")]
        public ItemInvoice[] Items { get; set; }

        [JsonPropertyName("fees")]
        public FeeInvoice[] Fees { get; set; }

        [JsonPropertyName("customer_notification_preference")]
        public CustomerNotificationPreferenceInvoice CustomerNotificationPreference { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Create invoice with all parameters as dictionary and headers.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see href="https://developers.xendit.co/api-reference/#create-invoice"/>.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Create(InvoiceBody parameter, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/v2/invoices");
            return await XenditConfiguration.RequestClient.Request<InvoiceBody, Invoice>(HttpMethod.Post, headers, url, parameter);
        }

        /// <summary>
        /// Get invoice detail by ID.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to retrieve.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> GetById(string invoiceId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/v2/invoices/", invoiceId);
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Invoice>(HttpMethod.Get, headers, url, null);
        }

        /// <summary>
        /// Get all invoices by given parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see href="https://developers.xendit.co/api-reference/#list-all-invoices"/>.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of array of invoices.</returns>
        public static async Task<Invoice[]> GetAll(ListInvoiceParameter? parameter = null, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            string queryParams = parameter != null ? QueryParamsBuilder.Build(parameter) : string.Empty;
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/v2/invoices?", queryParams);
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Invoice[]>(HttpMethod.Get, headers, url, null);
        }

        /// <summary>
        /// Expire an already created invoice.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to be expired / canceled.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Expire(string invoiceId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/invoices/", invoiceId, "/expire!");
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Invoice>(HttpMethod.Post, headers, url, new Dictionary<string, string>());
        }
    }
}
