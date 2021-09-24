namespace Xendit.net.Model.EWallet
{
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class EWalletPayment
    {
        /// <summary>
        /// Create new e-wallet payment.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletPaymentParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/create-payment"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletPaymentResponse"/>.</returns>
        public static async Task<EWalletPaymentResponse> Create(EWalletPaymentParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20200201)
        {
            return await CreateRequest(parameter, headers, apiVersion);
        }

        /// <summary>
        /// Get payment status of an single payment.
        /// </summary>
        /// <param name="externalId">Merchant provided unique ID.</param>
        /// <param name="ewalletType">Type of E-Wallet payment. Use values listed on <see cref="EWalletEnum.PaymentType"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/ewallets/get-payment-status"/>.</param>
        /// <returns>A Task of <see cref="EWalletPaymentResponse"/>.</returns>
        public static async Task<EWalletPaymentResponse> Get(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers = null)
        {
            return await GetRequest(externalId, ewalletType, headers);
        }

        private static async Task<EWalletPaymentResponse> CreateRequest(EWalletPaymentParameter parameter, HeaderParameter? headers, ApiVersion apiVersion)
        {
            EWalletPaymentClient client = new EWalletPaymentClient();
            return await client.Create(parameter, headers, apiVersion);
        }

        private static async Task<EWalletPaymentResponse> GetRequest(string externalId, EWalletEnum.PaymentType ewalletType, HeaderParameter? headers)
        {
            EWalletPaymentClient client = new EWalletPaymentClient();
            return await client.Get(externalId, ewalletType, headers);
        }
    }
}
