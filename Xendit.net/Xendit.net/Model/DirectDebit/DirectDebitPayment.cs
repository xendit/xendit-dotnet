namespace Xendit.net.Model.DirectDebit
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class DirectDebitPayment
    {
        /// <summary>
        /// Create direct debit payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DirectDebitPaymentParameter"/>.</param>
        /// <param name="idempotencyKey">Key provided by the merchant to prevent duplicate requests.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-direct-debit-payment"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public static async Task<DirectDebitPaymentResponse> Create(DirectDebitPaymentParameter parameter, string idempotencyKey, HeaderParameter? headers = null)
        {
            return await CreateRequest(parameter, idempotencyKey, headers);
        }

        /// <summary>
        /// Validate OTP for direct debit payment.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="directDebitId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-direct-debit-payment"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public static async Task<DirectDebitPaymentResponse> ValidateOtp(string otpCode, string directDebitId, HeaderParameter? headers = null)
        {
            return await ValidateOtpRequest(otpCode, directDebitId, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by Xendit transaction ID.
        /// </summary>
        /// <param name="id">Xendit identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-id"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public static async Task<DirectDebitPaymentResponse> GetById(string id, HeaderParameter? headers = null)
        {
            return await GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by merchant provided transaction ID.
        /// </summary>
        /// <param name="referenceId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public static async Task<DirectDebitPaymentResponse[]> GetByReferenceId(string referenceId, HeaderParameter? headers = null)
        {
            return await GetByReferenceIdRequest(referenceId, headers);
        }

        private static async Task<DirectDebitPaymentResponse> CreateRequest(DirectDebitPaymentParameter parameter, string idempotencyKey, HeaderParameter? headers)
        {
            DirectDebitPaymentClient client = new DirectDebitPaymentClient();
            return await client.Create(parameter, idempotencyKey, headers);
        }

        private static async Task<DirectDebitPaymentResponse> ValidateOtpRequest(string otpCode, string directDebitId, HeaderParameter? headers)
        {
            DirectDebitPaymentClient client = new DirectDebitPaymentClient();
            return await client.ValidateOtp(otpCode, directDebitId, headers);
        }

        private static async Task<DirectDebitPaymentResponse> GetByIdRequest(string id, HeaderParameter? headers)
        {
            DirectDebitPaymentClient client = new DirectDebitPaymentClient();
            return await client.GetById(id, headers);
        }

        private static async Task<DirectDebitPaymentResponse[]> GetByReferenceIdRequest(string referenceId, HeaderParameter? headers)
        {
            DirectDebitPaymentClient client = new DirectDebitPaymentClient();
            return await client.GetByReferenceId(referenceId, headers);
        }
    }
}
