namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Numerics;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Common;

    public class Invoice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

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
        public string Currency { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("paid_at")]
        public string PaidAt { get; set; }

        [JsonPropertyName("credit_card_charge_id")]
        public string CreditCardChargeId { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("payment_channel")]
        public string PaymentChannel { get; set; }

        [JsonPropertyName("payment_destination")]
        public string PaymentDestination { get; set; }

        [JsonPropertyName("fixed_va")]
        public bool FixedVa { get; set; }

        /// <summary>
        /// Get invoice detail by ID.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to retrieve.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> GetById(string invoiceId)
        {
            return await GetById(new Dictionary<string, string>(), invoiceId);
        }

        /// <summary>
        /// Get invoice detail by ID with custom headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="invoiceId">ID of the invoice to retrieve.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> GetById(Dictionary<string, string> headers, string invoiceId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/v2/invoices/", invoiceId);

            var invoice = await XenditConfiguration.RequestClient.Request<Invoice>(HttpMethod.Get, headers, url, null);
            return invoice;
        }

        /// <summary>
        /// Expire an already created invoice.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to be expired / canceled.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Expire(string invoiceId)
        {
            return await Expire(new Dictionary<string, string>(), invoiceId);
        }

        /// <summary>
        /// Expire an already created invoice.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="invoiceId">ID of the invoice to be expired / canceled.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Expire(Dictionary<string, string> headers, string invoiceId)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/invoices/", invoiceId, "/expire!");

            var invoice = await XenditConfiguration.RequestClient.Request<Invoice>(HttpMethod.Post, headers, url, new Dictionary<string, object>());
            return invoice;
        }

        /// <summary>
        /// Create invoice with all parameters as dictionary.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-invoice.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Create(Dictionary<string, object> parameter)
        {
            return await Create(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create invoice with required parameters.
        /// </summary>
        /// <param name="externalId">ID of your choice (typically the unique identifier of an invoice in your system).</param>
        /// <param name="amount">Amount on the invoice. The minimum amount to create an invoice is 10000.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Create(string externalId, long amount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("external_id", externalId);
            parameter.Add("amount", amount);

            return await Create(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create invoice with required parameters and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">ID of your choice (typically the unique identifier of an invoice in your system).</param>
        /// <param name="amount">Amount on the invoice. The minimum amount to create an invoice is 10000.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Create(Dictionary<string, string> headers, string externalId, long amount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("external_id", externalId);
            parameter.Add("amount", amount);

            return await Create(headers, parameter);
        }

        /// <summary>
        /// Create invoice with all parameters as dictionary and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-invoice.</param>
        /// <returns>A Task of Invoice model.</returns>
        public static async Task<Invoice> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/v2/invoices");

            var invoice = await XenditConfiguration.RequestClient.Request<Invoice>(HttpMethod.Post, headers, url, parameter);
            return invoice;
        }

        /// <summary>
        /// Get all invoices by given parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#list-all-invoices.</param>
        /// <returns>A Task of array of invoices.</returns>
        public static async Task<Invoice[]> GetAll(Dictionary<string, object> parameter)
        {
            return await GetAll(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Get all invoices by given parameters and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#list-all-invoices.</param>
        /// <returns>A Task of array of invoices.</returns>
        public static async Task<Invoice[]> GetAll(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string queryParams = string.Empty;

            string[] paramList = new string[]
            {
                "statuses",
                "limit",
                "created_after",
                "created_before",
                "paid_after",
                "paid_before",
                "expired_after",
                "expired_before",
                "last_invoice_id",
                "client_types",
                "payment_channels",
                "on_demand_link",
                "recurring_payment_id",
            };

            for (int i = 0; i < paramList.Length; i++)
            {
                string key = paramList[i];
                if (parameter.ContainsKey(key))
                {
                    queryParams += string.Format("{0}{1}{2}{3}", "&", key, "=", parameter[key]);
                }
            }

            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/v2/invoices?", queryParams);
            var invoices = await XenditConfiguration.RequestClient.Request<Invoice[]>(HttpMethod.Get, headers, url, null);
            return invoices;
        }
    }
}
