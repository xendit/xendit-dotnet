namespace Xendit.net.Model
{
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Disbursement
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("bank_code")]
        public DisbursementChannelCode BankCode { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonPropertyName("disbursement_description")]
        public string DisbursementDescription { get; set; }

        [JsonPropertyName("status")]
        public DisbursementStatus Status { get; set; }

        [JsonPropertyName("email_to")]
        public string[] EmailTo { get; set; }

        [JsonPropertyName("email_cc")]
        public string[] EmailCC { get; set; }

        [JsonPropertyName("email_bcc")]
        public string[] EmailBCC { get; set; }

        /// <summary>
        /// Create disbursement with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-disbursement.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(DisbursementParameter parameter, HeaderParameter? headers = null)
        {
            return await CreateDisbursementRequest(parameter, headers);
        }

        /// <summary>
        /// Get disbursement object by ID.
        /// </summary>
        /// <param name="id">ID of disbursement.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> GetById(string id, HeaderParameter? headers = null)
        {
            return await GetByIdRequest(id, headers);
        }

        /// <summary>
        /// Get disbursement object by external ID.
        /// </summary>
        /// <param name="externalId">External ID of disbursement.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement[]> GetByExternalId(string externalId, HeaderParameter? headers = null)
        {
            return await GetByExternalIdRequest(externalId, headers);
        }

        /// <summary>
        /// Get available banks for disbursement.
        /// </summary>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>.</param>
        /// <returns>A Task of <see cref="AvailableBank[]"/>.</returns>
        public static async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            return await GetAvailableBanksRequest(headers);
        }

        private static async Task<Disbursement> GetByIdRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements/", id);

            return await XenditConfiguration.RequestClient.Request<Disbursement>(HttpMethod.Get, headers, url);
        }

        private static async Task<Disbursement[]> GetByExternalIdRequest(string externalId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements?external_id=", externalId);

            return await XenditConfiguration.RequestClient.Request<Disbursement[]>(HttpMethod.Get, headers, url);
        }

        private static async Task<AvailableBank[]> GetAvailableBanksRequest(HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_disbursements_banks");

            return await XenditConfiguration.RequestClient.Request<AvailableBank[]>(HttpMethod.Get, headers, url);
        }

        private static async Task<Disbursement> CreateDisbursementRequest(DisbursementParameter parameter, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/disbursements");

            return await XenditConfiguration.RequestClient.Request<DisbursementParameter, Disbursement>(HttpMethod.Post, headers, url, parameter);
        }
    }
}
