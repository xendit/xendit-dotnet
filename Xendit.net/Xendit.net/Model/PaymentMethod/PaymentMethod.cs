namespace Xendit.net.Model.PaymentMethod
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class PaymentMethod
    {
        /// <summary>
        /// Create payment method with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="PaymentMethodParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-payment-method"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethodResponse"/>.</returns>
        public static async Task<PaymentMethodResponse> Create(PaymentMethodParameter parameter, HeaderParameter? headers = null)
        {
            PaymentMethodClient client = new PaymentMethodClient();
            return await client.Create(parameter, headers);
        }

        /// <summary>
        /// Get payment methods by customer id.
        /// </summary>
        /// <param name="customerId">Customer object ID of interest.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of <see cref="PaymentMethodResponse[]"/>.</returns>
        public static async Task<PaymentMethodResponse[]> Get(string customerId, HeaderParameter? headers = null)
        {
            PaymentMethodClient client = new PaymentMethodClient();
            return await client.Get(customerId, headers);
        }
    }
}
