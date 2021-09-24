namespace Xendit.net.Model.EWallet
{
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class EWalletCharge
    {
        /// <summary>
        /// Create new e-wallet charge with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletChargeParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-ewallet-charge"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletChargeResponse"/>.</returns>
        public static async Task<EWalletChargeResponse> Create(EWalletChargeParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            return await CreateChargeRequest(parameter, headers, apiVersion);
        }

        /// <summary>
        /// Get e-Wallet charge by id.
        /// </summary>
        /// <param name="chargeId">E-Wallet charge ID.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-ewallet-charge-status"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletChargeResponse"/>.</returns>
        public static async Task<EWalletChargeResponse> Get(string chargeId, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            return await GetChargeRequest(chargeId, headers, apiVersion);
        }

        private static async Task<EWalletChargeResponse> CreateChargeRequest(EWalletChargeParameter parameter, HeaderParameter? headers, ApiVersion apiVersion)
        {
            EWalletChargeClient client = new EWalletChargeClient();
            return await client.Create(parameter, headers, apiVersion);
        }

        private static async Task<EWalletChargeResponse> GetChargeRequest(string id, HeaderParameter? headers, ApiVersion apiVersion)
        {
            EWalletChargeClient client = new EWalletChargeClient();
            return await client.Get(id, headers, apiVersion);
        }
    }
}
