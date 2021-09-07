namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class RetailOutlet
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }

        [JsonPropertyName("payment_code")]
        public string PaymentCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("channel_code")]
        public string ChannelCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonPropertyName("payment_code_id")]
        public string PaymentCodeId { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        /// <summary>
        /// Create fixed payment code.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CreateRetailOutletParameter"/>.</param>
        /// <param name="headers">Header listed here <see href="https://developers.xendit.co/api-reference/#create-payment-code"/>.</param>
        /// <returns>A Task of Retail Outlet model.</returns>
        public static async Task<RetailOutlet> Create(CreateRetailOutletParameter parameter, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await CreateRequest(parameter, headers);
        }

        /// <summary>
        /// Update fixed payment code by ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="UpdateRetailOutletParameter"/>.</param>
        /// <param name="paymentCodeId">ID of the payment code to be updated.</param>
        /// <param name="headers">Headers listed here <see href="https://developers.xendit.co/api-reference/#update-payment-code"/>.</param>
        /// <returns>A Task of Retail Outlet model.</returns>
        public static async Task<RetailOutlet> Update(UpdateRetailOutletParameter parameter, string paymentCodeId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await UpdateRequest(parameter, paymentCodeId, headers);
        }

        /// <summary>
        /// Get fixed payment code by ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve.</param>
        /// <param name="headers">Headers listed here <see href="https://developers.xendit.co/api-reference/#get-payment-code"/>.</param>
        /// <returns>A Task of Retail Outlet model.</returns>
        public static async Task<RetailOutlet> GetPaymentCode(string paymentCodeId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetPaymentCodeRequest(paymentCodeId, headers);
        }

        /// <summary>
        /// Get payments by ID of the payment code.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve payments made.</param>
        /// <param name="headers">Headers listed here <see href="https://developers.xendit.co/api-reference/#get-payments-by-payment-code-id"/></param>
        /// <returns>A Task of Retail Outlet model.</returns>
        public static async Task<RetailOutlet[]> GetPayments(string paymentCodeId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await GetPaymentsRequest(paymentCodeId, headers);
        }

        private static async Task<RetailOutlet> CreateRequest(CreateRetailOutletParameter parameter, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/payment_codes");
            return await XenditConfiguration.RequestClient.Request<CreateRetailOutletParameter, RetailOutlet>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<RetailOutlet> UpdateRequest(UpdateRetailOutletParameter parameter, string paymentCodeId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId);
            return await XenditConfiguration.RequestClient.Request<UpdateRetailOutletParameter, RetailOutlet>(HttpMethod.Patch, headers, url, parameter);
        }

        private static async Task<RetailOutlet> GetPaymentCodeRequest(string paymentCodeId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId);
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, RetailOutlet>(HttpMethod.Get, headers, url, null);
        }

        private static async Task<RetailOutlet[]> GetPaymentsRequest(string paymentCodeId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId, "/payments");
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, RetailOutlet[]>(HttpMethod.Get, headers, url, null);
        }
    }
}
