namespace Xendit.net.Model.RetailOutlet
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class RetailOutletClient : BaseClient
    {
        public RetailOutletClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create fixed payment code.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CreateFixedPaymentCodeParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#create-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public async Task<FixedPaymentCode> CreatePaymentCode(CreateFixedPaymentCodeParameter parameter, HeaderParameter? headers = null)
        {
            if (parameter.Currency != Currency.PHP || parameter.Market != Country.Philippines)
            {
                throw new ParamException("Create Payment Code can only accept Currency.PHP and Country.Philippines");
            }

            string url = "/payment_codes";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        /// <summary>
        /// Update fixed payment code by ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="UpdateFixedPaymentCodeParameter"/>.</param>
        /// <param name="paymentCodeId">ID of the payment code to be updated.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#update-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public async Task<FixedPaymentCode> UpdatePaymentCode(UpdateFixedPaymentCodeParameter parameter, string paymentCodeId, HeaderParameter? headers = null)
        {
            if (parameter.Currency != Currency.PHP)
            {
                throw new ParamException("Update Payment Code can only accept Currency.PHP");
            }

            string url = string.Format("{0}{1}", "/payment_codes/", paymentCodeId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        /// <summary>
        /// Get fixed payment code by ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public async Task<FixedPaymentCode> GetPaymentCode(string paymentCodeId, HeaderParameter? headers = null)
        {
            string url = string.Format("{0}{1}", "/payment_codes/", paymentCodeId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<FixedPaymentCode>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }

        /// <summary>
        /// Get payments by payment code ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve payments made.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payments-by-payment-code-id"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode[]"/>.</returns>
        public async Task<FixedPaymentCode[]> GetPayments(string paymentCodeId, HeaderParameter? headers = null)
        {
            string url = string.Format("{0}{1}{2}", "/payment_codes/", paymentCodeId, "/payments");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<FixedPaymentCode[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }
    }
}
