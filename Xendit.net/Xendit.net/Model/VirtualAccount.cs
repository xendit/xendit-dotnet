using System;
using System.Collections.Generic;
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

            var result = await XenditConfiguration.requestClient.Request(headers, url);
            var availableBanks = await JsonSerializer.DeserializeAsync<List<AvailableBank>>(result);
            return availableBanks;
        }

        public static Task<VirtualAccount> Get(string id)
        {
            return Get(new Dictionary<string, string>(), id);
        }

        public static async Task<VirtualAccount> Get(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_accounts/", id);

            var result = await XenditConfiguration.requestClient.Request(headers, url);
            var virtualAccount = await JsonSerializer.DeserializeAsync<VirtualAccount>(result);
            return virtualAccount;
        }
    }
}
