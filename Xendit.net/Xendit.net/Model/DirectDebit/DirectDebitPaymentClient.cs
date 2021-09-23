namespace Xendit.net.Model.DirectDebit
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class DirectDebitPaymentClient : BaseClient
    {
        public DirectDebitPaymentClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create direct debit payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DirectDebitPaymentParameter"/>.</param>
        /// <param name="idempotencyKey">Key provided by the merchant to prevent duplicate requests.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-direct-debit-payment"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public async Task<DirectDebitPaymentResponse> Create(DirectDebitPaymentParameter parameter, string idempotencyKey, HeaderParameter? headers = null)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.Idempotencykey = idempotencyKey;
            return await this.CreateRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Validate OTP for direct debit payment.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="directDebitId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-direct-debit-payment"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public async Task<DirectDebitPaymentResponse> ValidateOtp(string otpCode, string directDebitId, HeaderParameter? headers = null)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>()
            {
                { "otp_code", otpCode },
            };

            return await this.ValidateOtpRequest(parameter, directDebitId, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by Xendit transaction ID.
        /// </summary>
        /// <param name="id">Xendit identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-id"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public async Task<DirectDebitPaymentResponse> GetById(string id, HeaderParameter? headers = null)
        {
            return await this.GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Retrieve the details of a direct debit payment by merchant provided transaction ID.
        /// </summary>
        /// <param name="referenceId">Merchant provided identifier for specified direct debit transaction.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-payment-by-reference-id"/>.</param>
        /// <returns>A Task of <see cref="DirectDebitPaymentResponse"/>.</returns>
        public async Task<DirectDebitPaymentResponse[]> GetByReferenceId(string referenceId, HeaderParameter? headers = null)
        {
            return await this.GetByReferenceIdRequest(referenceId, headers);
        }

        private async Task<DirectDebitPaymentResponse> CreateRequest(DirectDebitPaymentParameter parameter, HeaderParameter? headers)
        {
            string url = "/direct_debits";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DirectDebitPaymentParameter, DirectDebitPaymentResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<DirectDebitPaymentResponse> ValidateOtpRequest(Dictionary<string, string> parameter, string directDebitId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/direct_debits/", directDebitId, "/validate_otp/");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<Dictionary<string, string>, DirectDebitPaymentResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<DirectDebitPaymentResponse> GetByIdRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/direct_debits/", id, "/");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DirectDebitPaymentResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }

        private async Task<DirectDebitPaymentResponse[]> GetByReferenceIdRequest(string referenceId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/direct_debits?reference_id=", referenceId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DirectDebitPaymentResponse[]>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
