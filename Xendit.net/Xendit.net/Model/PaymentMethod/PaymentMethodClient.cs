namespace Xendit.net.Model.PaymentMethod
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class PaymentMethodClient : BaseClient
    {
        public PaymentMethodClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create payment method with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="PaymentMethodParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-payment-method"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethodResponse"/>.</returns>
        public async Task<PaymentMethodResponse> Create(PaymentMethodParameter parameter, HeaderParameter? headers = null)
        {
            return await this.CreatePaymentMethodRequest(parameter, headers);
        }

        /// <summary>
        /// Get payment methods by customer id.
        /// </summary>
        /// <param name="customerId">Customer object ID of interest.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethodResponse[]"/>.</returns>
        public async Task<PaymentMethodResponse[]> Get(string customerId, HeaderParameter? headers = null)
        {
            return await this.GetPaymentMethodRequest(customerId, headers);
        }

        private async Task<PaymentMethodResponse> CreatePaymentMethodRequest(PaymentMethodParameter parameter, HeaderParameter? headers)
        {
            string url = "/payment_methods";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<PaymentMethodParameter, PaymentMethodResponse>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        private async Task<PaymentMethodResponse[]> GetPaymentMethodRequest(string customerId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/payment_methods?customer_id=", customerId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<PaymentMethodResponse[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }
    }
}
