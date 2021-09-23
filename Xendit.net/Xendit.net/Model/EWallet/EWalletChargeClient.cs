namespace Xendit.net.Model.EWallet
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class EWalletChargeClient : BaseClient
    {
        public EWalletChargeClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create new e-wallet charge with all parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="EWalletChargeParameter"/>. </param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-ewallet-charge"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletChargeResponse"/>.</returns>
        public async Task<EWalletChargeResponse> Create(EWalletChargeParameter parameter, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await this.CreateChargeRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Get e-Wallet charge by id.
        /// </summary>
        /// <param name="chargeId">E-Wallet charge ID.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-ewallet-charge-status"/>.</param>
        /// <param name="apiVersion">API version that will be used to request. Use values listed on <see href="https://developers.xendit.co/api-reference/#ewallets"/>.</param>
        /// <returns>A Task of <see cref="EWalletChargeResponse"/>.</returns>
        public async Task<EWalletChargeResponse> Get(string chargeId, HeaderParameter? headers = null, ApiVersion apiVersion = ApiVersion.Version20210125)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.XApiVersion = apiVersion;
            return await this.GetChargeRequest(chargeId, validHeaders);
        }

        private async Task<EWalletChargeResponse> CreateChargeRequest(EWalletChargeParameter parameter, HeaderParameter? headers)
        {
            string url = "/ewallets/charges";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<EWalletChargeParameter, EWalletChargeResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<EWalletChargeResponse> GetChargeRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/ewallets/charges/", id);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<EWalletChargeResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
