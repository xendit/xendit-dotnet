﻿namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class PaymentMethod
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, object> Properties { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Create payment method with all parameter as Dictionary.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-payment-method.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Payment Method model.</returns>
        public static async Task<PaymentMethod> Create(Dictionary<string, object> parameter, Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            return await CreatePaymentMethodRequest(headers, parameter);
        }

        /// <summary>
        /// Get payment methods by customer id.
        /// </summary>
        /// <param name="customerId">Customer object ID of interest.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of array of Payment Method models.</returns>
        public static async Task<PaymentMethod[]> Get(string customerId, Dictionary<string, string> headers = null)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            return await GetPaymentMethodRequest(headers, customerId);
        }

        private static async Task<PaymentMethod> CreatePaymentMethodRequest(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/payment_methods");
            return await XenditConfiguration.RequestClient.Request<PaymentMethod>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<PaymentMethod[]> GetPaymentMethodRequest(Dictionary<string, string> headers, string customerId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_methods?customer_id=", customerId);
            return await XenditConfiguration.RequestClient.Request<PaymentMethod[]>(HttpMethod.Get, headers, url, null);
        }
    }
}