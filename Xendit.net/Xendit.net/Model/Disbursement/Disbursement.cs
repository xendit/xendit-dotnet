namespace Xendit.net.Model.Disbursement
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class Disbursement
    {
        /// <summary>
        /// Create disbursement with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="DisbursementParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-disbursement"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse"/>.</returns>
        public static async Task<DisbursementResponse> Create(DisbursementParameter parameter, HeaderParameter? headers = null)
        {
            return await CreateDisbursementRequest(parameter, headers);
        }

        /// <summary>
        /// Get disbursement object by ID.
        /// </summary>
        /// <param name="id">ID of disbursement.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-disbursement-by-id"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse"/>.</returns>
        public static async Task<DisbursementResponse> GetById(string id, HeaderParameter? headers = null)
        {
            return await GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Get disbursement object by external ID.
        /// </summary>
        /// <param name="externalId">External ID of disbursement.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-disbursements-by-external-id"/>.</param>
        /// <returns>A Task of <see cref="DisbursementResponse[]"/>.</returns>
        public static async Task<DisbursementResponse[]> GetByExternalId(string externalId, HeaderParameter? headers = null)
        {
            return await GetByExternalIdRequest(externalId, headers);
        }

        /// <summary>
        /// Get available banks for disbursement.
        /// </summary>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-available-banks">.</see></param>
        /// <returns>A Task of <see cref="AvailableBank[]"/>.</returns>
        public static async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            return await GetAvailableBanksRequest(headers);
        }

        private static async Task<DisbursementResponse> CreateDisbursementRequest(DisbursementParameter parameter, HeaderParameter? headers)
        {
            DisbursementClient client = new DisbursementClient();
            return await client.Create(parameter, headers);
        }

        private static async Task<DisbursementResponse> GetByIdRequest(string id, HeaderParameter? headers)
        {
            DisbursementClient client = new DisbursementClient();
            return await client.GetById(id, headers);
        }

        private static async Task<DisbursementResponse[]> GetByExternalIdRequest(string externalId, HeaderParameter? headers)
        {
            DisbursementClient client = new DisbursementClient();
            return await client.GetByExternalId(externalId, headers);
        }

        private static async Task<AvailableBank[]> GetAvailableBanksRequest(HeaderParameter? headers)
        {
            DisbursementClient client = new DisbursementClient();
            return await client.GetAvailableBanks(headers);
        }
    }
}
