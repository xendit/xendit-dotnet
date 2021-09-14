namespace Xendit.net.Model
{
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class VirtualAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("bank_code")]
        public VirtualAccountEnum.BankCode BankCode { get; set; }

        [JsonPropertyName("merchant_code")]
        public string MerchantCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("is_closed")]
        public bool IsClosed { get; set; }

        [JsonPropertyName("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonPropertyName("status")]
        public VirtualAccountEnum.Status Status { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("expected_amount")]
        public long ExpectedAmount { get; set; }

        [JsonPropertyName("suggested_amount")]
        public long SuggestedAmount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Create Closed Virtual Account with complete parameter.
        /// </summary>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static async Task<VirtualAccount> Create(CreateVirtualAccountParameter parameter, HeaderParameter? headers = null)
        {
            return await CreateRequest(parameter, headers);
        }

        /// <summary>
        /// Get Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the virtual account to retrieve.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static async Task<VirtualAccount> Get(string id, HeaderParameter? headers = null)
        {
            return await GetRequest(id, headers);
        }

        /// <summary>
        /// Update Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the fixed virtual account to update.</param>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#update-fixed-virtual-account.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static async Task<VirtualAccount> Update(UpdateVirtualAccountParameter parameter, string id, HeaderParameter? headers = null)
        {
            return await UpdateRequest(parameter, id, headers);
        }

        public static async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            return await GetAvailableBanksRequest(headers);
        }

        private static async Task<VirtualAccount> CreateRequest(CreateVirtualAccountParameter parameter, HeaderParameter? headers = null)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts");
            return await XenditConfiguration.RequestClient.Request<CreateVirtualAccountParameter, VirtualAccount>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<VirtualAccount> UpdateRequest(UpdateVirtualAccountParameter parameter, string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            return await XenditConfiguration.RequestClient.Request<UpdateVirtualAccountParameter, VirtualAccount>(XenditHttpMethod.Patch, headers, url, parameter);
        }

        private static async Task<VirtualAccount> GetRequest(string id, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            return await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Get, headers, url);
        }

        private static async Task<AvailableBank[]> GetAvailableBanksRequest(HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_virtual_account_banks");

            return await XenditConfiguration.RequestClient.Request<AvailableBank[]>(HttpMethod.Get, headers, url);
        }
    }
}
