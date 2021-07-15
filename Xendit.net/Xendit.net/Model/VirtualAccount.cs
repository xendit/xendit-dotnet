using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xendit.net.Model
{
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

        public static Task<List<AvailableBank>> GetAvailableBanks()
        {
            return GetAvailableBanks(new Dictionary<string, string>());
        }

        public static async Task<List<AvailableBank>> GetAvailableBanks(Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_virtual_account_banks");

            var listAvailableBanks = await XenditConfiguration.RequestClient.Request<List<AvailableBank>>(HttpMethod.Get, headers, url, null);
            return listAvailableBanks;
        }

        public static Task<VirtualAccount> Get(string id)
        {
            return Get(new Dictionary<string, string>(), id);
        }

        public static async Task<VirtualAccount> Get(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Get, headers, url, null);
            return virtualAccount;
        }

        public static Task<VirtualAccount> Create(Dictionary<string, object> parameter)
        {
            return Create(new Dictionary<string, string>(), parameter);
        }

        public static async Task<VirtualAccount> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts");

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Post, headers, url, parameter);
            return virtualAccount;
        }

        public static Task<VirtualAccount> Update(string id, Dictionary<string, object> parameter)
        {
            return Update(new Dictionary<string, string>(), id, parameter);
        }

        public static async Task<VirtualAccount> Update(Dictionary<string, string> headers, string id, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            var virtualAccount = await XenditConfiguration.RequestClient.Request<VirtualAccount>(HttpMethod.Patch, headers, url, parameter);
            return virtualAccount;
        }
    }
}
