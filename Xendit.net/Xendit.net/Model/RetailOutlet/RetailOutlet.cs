namespace Xendit.net.Model.RetailOutlet
{
    using System.Threading.Tasks;
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
            RetailOutletClient client = new RetailOutletClient();
            return await client.CreatePaymentCode(parameter, headers);
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
            RetailOutletClient client = new RetailOutletClient();
            return await client.UpdatePaymentCode(parameter, paymentCodeId, headers);
        }

        /// <summary>
        /// Get fixed payment code by ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payment-code"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode"/>.</returns>
        public static async Task<FixedPaymentCode> GetPaymentCode(string paymentCodeId, HeaderParameter? headers = null)
        {
            RetailOutletClient client = new RetailOutletClient();
            return await client.GetPaymentCode(paymentCodeId, headers);
        }

        /// <summary>
        /// Get payments by fixed payment code ID.
        /// </summary>
        /// <param name="fixedPaymentCode">The fixed payment code ID.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payments-by-fixed-payment-code-id"/>.</param>
        /// <returns>A Task of <see cref="PaymentsResponse"/>.</returns>
        public static async Task<PaymentsResponse> GetPaymentsByFixedPaymentCode(string fixedPaymentCode, HeaderParameter? headers = null)
        {
            RetailOutletClient client = new RetailOutletClient();
            return await client.GetPaymentsByFixedPaymentCode(fixedPaymentCode, headers);
        }

        /// <summary>
        /// Get payments by payment code ID.
        /// </summary>
        /// <param name="paymentCodeId">ID of the payment code to retrieve payments made.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property listed here <see href="https://developers.xendit.co/api-reference/#get-payments-by-payment-code-id"/>.</param>
        /// <returns>A Task of <see cref="FixedPaymentCode[]"/>.</returns>
        public static async Task<FixedPaymentCode[]> GetPayments(string paymentCodeId, HeaderParameter? headers = null)
        {
            RetailOutletClient client = new RetailOutletClient();
            return await client.GetPayments(paymentCodeId, headers);
        }
    }
}
