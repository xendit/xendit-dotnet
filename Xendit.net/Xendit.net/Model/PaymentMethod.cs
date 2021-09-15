﻿namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class PaymentMethod
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public PaymentMethodEnum.AccountType Type { get; set; }

        [JsonPropertyName("properties")]
        public PaymentMethodProperties Properties { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("status")]
        public PaymentMethodEnum.Status Status { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Create payment method with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="PaymentMethodParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-payment-method"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethod"/>.</returns>
        public static async Task<PaymentMethod> Create(PaymentMethodParameter parameter, HeaderParameter? headers = null)
        {
            return await CreatePaymentMethodRequest(headers, parameter);
        }

        /// <summary>
        /// Get payment methods by customer id.
        /// </summary>
        /// <param name="customerId">Customer object ID of interest.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethod[]"/>.</returns>
        public static async Task<PaymentMethod[]> Get(string customerId, HeaderParameter? headers = null)
        {
            return await GetPaymentMethodRequest(headers, customerId);
        }

        private static async Task<PaymentMethod> CreatePaymentMethodRequest(HeaderParameter? headers, PaymentMethodParameter parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/payment_methods");
            return await XenditConfiguration.RequestClient.Request<PaymentMethodParameter, PaymentMethod>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<PaymentMethod[]> GetPaymentMethodRequest(HeaderParameter? headers, string customerId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_methods?customer_id=", customerId);
            return await XenditConfiguration.RequestClient.Request<PaymentMethod[]>(HttpMethod.Get, headers, url);
        }
    }
}
