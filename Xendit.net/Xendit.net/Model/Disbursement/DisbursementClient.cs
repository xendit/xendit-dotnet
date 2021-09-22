namespace Xendit.net.Model.Disbursement
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class DisbursementClient : BaseClient
    {
        public DisbursementClient(string apiKey = null, INetworkClient networkClient = null, string baseUrl = null)
            : base(apiKey, networkClient, baseUrl)
        {
        }

        /// <summary>
        /// Create disbursement with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DisbursementParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-disbursement"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse"/>.</returns>
        public async Task<DisbursementResponse> Create(DisbursementParameter parameter, HeaderParameter? headers = null)
        {
            return await this.CreateDisbursementRequest(parameter, headers);
        }

        /// <summary>
        /// Get disbursement object by ID.
        /// </summary>
        /// <param name="id">ID of disbursement.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-disbursement-by-id"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse"/>.</returns>
        public async Task<DisbursementResponse> GetById(string id, HeaderParameter? headers = null)
        {
            return await this.GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Get disbursement object by external ID.
        /// </summary>
        /// <param name="externalId">External ID of disbursement.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-disbursements-by-external-id"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse[]"/>.</returns>
        public async Task<DisbursementResponse[]> GetByExternalId(string externalId, HeaderParameter? headers = null)
        {
            return await this.GetByExternalIdRequest(externalId, headers);
        }

        /// <summary>
        /// Get available banks for disbursement.
        /// </summary>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-available-banks">.</see></param>
        /// <returns>A Task of <see cref="AvailableBank[]"/>.</returns>
        public async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            return await this.GetAvailableBanksRequest(headers);
        }

        private async Task<DisbursementResponse> CreateDisbursementRequest(DisbursementParameter parameter, HeaderParameter? headers)
        {
            string url = "/disbursements";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DisbursementParameter, DisbursementResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<DisbursementResponse> GetByIdRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/disbursements/", id);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DisbursementResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }

        private async Task<DisbursementResponse[]> GetByExternalIdRequest(string externalId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/disbursements?external_id=", externalId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<DisbursementResponse[]>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }

        private async Task<AvailableBank[]> GetAvailableBanksRequest(HeaderParameter? headers)
        {
            string url = "/available_disbursements_banks";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<AvailableBank[]>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
