namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Exception;
    using Xendit.net.Network;

    public class VirtualAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

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
        public string Status { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("expected_amount")]
        public long ExpectedAmount { get; set; }

        [JsonPropertyName("suggested_amount")]
        public long SuggestedAmount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Get available banks.
        /// </summary>
        /// <returns>A Task of list of available banks.</returns>
        public static Task<List<AvailableBank>> GetAvailableBanks()
        {
            return GetAvailableBanks(new Dictionary<string, string>());
        }

        /// <summary>
        /// Get available banks with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of list of available banks.</returns>
        public static async Task<List<AvailableBank>> GetAvailableBanks(Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_virtual_account_banks");

            var listAvailableBanks = await XenditConfiguration.RequestClient.Request<List<AvailableBank>>(HttpMethod.Get, headers, url, null);
            return listAvailableBanks;
        }

        /// <summary>
        /// Get Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the virtual account to retrieve.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> Get(string id)
        {
            return Get(new Dictionary<string, string>(), id);
        }

        /// <summary>
        /// Get Virtual Account based on its ID with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="id">ID of the virtual account to retrieve.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static async Task<VirtualAccount> Get(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Get, headers, url, null);
            return virtualAccount;
        }

        /// <summary>
        /// Create Closed Virtual Account with complete parameter.
        /// </summary>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(Dictionary<string, object> parameter)
        {
            return Create(new Dictionary<string, string>(), parameter, true);
        }

        /// <summary>
        /// Create Closed Virtual Account with complete parameter and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return Create(headers, parameter, true);
        }

        /// <summary>
        /// Create Closed Virtual Account with only required parameters.
        /// </summary>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <param name="expectedAmount">Expected payment amount for this Virtual Account.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(string externalId, string bankCode, string name, long expectedAmount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "name", name },
                { "expected_amount", expectedAmount },
            };

            return Create(new Dictionary<string, string>(), parameter, true);
        }

        /// <summary>
        /// Create Closed Virtual Account with only required parameters and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <param name="expectedAmount">Expected payment amount for this Virtual Account.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(Dictionary<string, string> headers, string externalId, string bankCode, string name, long expectedAmount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "name", name },
                { "expected_amount", expectedAmount },
            };

            return Create(headers, parameter, true);
        }

        /// <summary>
        /// Create Closed Virtual Account with required parameters and can accept additional params.
        /// </summary>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's name.</param>
        /// <param name="expectedAmount">Expected payment amount for this Virtual Account.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(string externalId, string bankCode, string name, long expectedAmount, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("name", name);
            parameter.Add("expected_amount", expectedAmount);

            return Create(new Dictionary<string, string>(), parameter, true);
        }

        /// <summary>
        /// Create Closed Virtual Account using required parameters and can accept additional params, with custom headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's name.</param>
        /// <param name="expectedAmount">Expected payment amount for this Virtual Account.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateClosed(Dictionary<string, string> headers, string externalId, string bankCode, string name, long expectedAmount, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("name", name);
            parameter.Add("expected_amount", expectedAmount);

            return Create(headers, parameter, true);
        }

        /// <summary>
        /// Create Open Virtual Account with complete parameter.
        /// </summary>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(Dictionary<string, object> parameter)
        {
            return Create(new Dictionary<string, string>(), parameter, false);
        }

        /// <summary>
        /// Create Open Virtual Account with complete parameter and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return Create(headers, parameter, false);
        }

        /// <summary>
        /// Create Open Virtual Account with only required parameters.
        /// </summary>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(string externalId, string bankCode, string name)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "name", name },
            };

            return Create(new Dictionary<string, string>(), parameter, false);
        }

        /// <summary>
        /// Create Open Virtual Account with only required parameters and custom headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(Dictionary<string, string> headers, string externalId, string bankCode, string name)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "name", name },
            };

            return Create(headers, parameter, false);
        }

        /// <summary>
        /// Create Open Virtual Account with required parameters and can accept additional params.
        /// </summary>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(string externalId, string bankCode, string name, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("name", name);

            return Create(new Dictionary<string, string>(), parameter, false);
        }

        /// <summary>
        /// Create Open Virtual Account with required parameters and can accept additional params, with custom headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">An ID of your choice, usually something that link Xendit Virtual Account with your internal system.</param>
        /// <param name="bankCode">Bank code of the Virtual Account you want to create.</param>
        /// <param name="name">Name of the Virtual Account, usually your end user's name or your company's.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> CreateOpen(Dictionary<string, string> headers, string externalId, string bankCode, string name, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("name", name);

            return Create(headers, parameter, false);
        }

        /// <summary>
        /// Update Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the fixed virtual account to update.</param>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#update-fixed-virtual-account.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static Task<VirtualAccount> Update(string id, Dictionary<string, object> parameter)
        {
            return Update(new Dictionary<string, string>(), id, parameter);
        }

        /// <summary>
        /// Update Virtual Account based on its ID with optional headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="id">ID of the fixed virtual account to update.</param>
        /// <param name="parameter">Params listed here https://developers.xendit.co/api-reference/#update-fixed-virtual-account.</param>
        /// <returns>A Task of Virtual Account model.</returns>
        public static async Task<VirtualAccount> Update(Dictionary<string, string> headers, string id, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(XenditHttpMethod.Patch, headers, url, parameter);
            return virtualAccount;
        }

        private static async Task<VirtualAccount> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter, bool isClosed)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts");

            if (!parameter.ContainsKey("is_closed"))
            {
                parameter.Add("is_closed", isClosed);
            }

            if (isClosed && parameter.ContainsKey("suggested_amount"))
            {
                throw new ParamException("Suggested amount is not supported for closed Virtual Account");
            }

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Post, headers, url, parameter);
            return virtualAccount;
        }
    }
}
