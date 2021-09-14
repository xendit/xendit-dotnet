namespace Xendit.net.Model
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class RetailOutlet
    {
        /// <summary>
        /// Create fixed payment code.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CreateFixedPaymentCodeParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#create-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public static async Task<FixedPaymentCode> CreatePaymentCode(CreateFixedPaymentCodeParameter parameter, HeaderParameter? headers = null)
        {
            return await CreatePaymentCodeRequest(parameter, headers);
        }

        /// <summary>
        /// Update fixed payment code by ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="UpdateFixedPaymentCodeParameter"/>.</param>
        /// <param name="paymentCodeId">ID of the payment code to be updated.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#update-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public static async Task<FixedPaymentCode> UpdatePaymentCode(UpdateFixedPaymentCodeParameter parameter, string paymentCodeId, HeaderParameter? headers = null)
        {
            return await UpdatePaymentCodeRequest(parameter, paymentCodeId, headers);
        }

        /// <summary>
        /// Get fixed payment code by ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public static async Task<FixedPaymentCode> GetPaymentCode(string paymentCodeId, HeaderParameter? headers = null)
        {
            return await GetPaymentCodeRequest(paymentCodeId, headers);
        }

        /// <summary>
        /// Get payments by payment code ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve payments made.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payments-by-payment-code-id"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode[]"/>.</returns>
        public static async Task<FixedPaymentCode[]> GetPayments(string paymentCodeId, HeaderParameter? headers = null)
        {
            return await GetPaymentsRequest(paymentCodeId, headers);
        }

        private static async Task<FixedPaymentCode> CreatePaymentCodeRequest(CreateFixedPaymentCodeParameter parameter, HeaderParameter? headers)
        {
            if (parameter.Currency != Currency.PHP || parameter.Market != Country.Philippines)
            {
                throw new ParamException("Create Payment Code can only accept Currency.PHP and Country.Philippines");
            }

            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/payment_codes");
            return await XenditConfiguration.RequestClient.Request<CreateFixedPaymentCodeParameter, FixedPaymentCode>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<FixedPaymentCode> UpdatePaymentCodeRequest(UpdateFixedPaymentCodeParameter parameter, string paymentCodeId, HeaderParameter? headers)
        {
            if (parameter.Currency != Currency.PHP)
            {
                throw new ParamException("Update Payment Code can only accept Currency.PHP");
            }

            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId);
            return await XenditConfiguration.RequestClient.Request<UpdateFixedPaymentCodeParameter, FixedPaymentCode>(XenditHttpMethod.Patch, headers, url, parameter);
        }

        private static async Task<FixedPaymentCode> GetPaymentCodeRequest(string paymentCodeId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId);
            return await XenditConfiguration.RequestClient.Request<FixedPaymentCode>(HttpMethod.Get, headers, url);
        }

        private static async Task<FixedPaymentCode[]> GetPaymentsRequest(string paymentCodeId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/payment_codes/", paymentCodeId, "/payments");
            return await XenditConfiguration.RequestClient.Request<FixedPaymentCode[]>(HttpMethod.Get, headers, url);
        }
    }
}
