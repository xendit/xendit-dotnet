namespace Xendit.net.Model
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Balance
    {
        [JsonPropertyName("balance")]
        public long Value { get; set; }

        /// <summary>
        /// Get balance from your account based on given account type.
        /// </summary>
        /// <param name="accountType">Selected balance type (in enum).</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <seealso href="https://developers.xendit.co/api-reference/#get-balance"/>.</param>
        /// <returns>A Task of <see cref="Balance"/>.</returns>
        public static async Task<Balance> Get(BalanceAccountType? accountType = null, HeaderParameter? headers = null)
        {
            return await GetBalanceRequest(accountType, headers);
        }

        private static async Task<Balance> GetBalanceRequest(BalanceAccountType? accountType, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/balance");

            if (accountType != null)
            {
                string accountTypeParam = JsonSerializer.Deserialize<string>(JsonSerializer.Serialize(accountType));
                url = string.Format("{0}{1}{2}", url, "?account_type=", accountTypeParam);
            }

            var balance = await XenditConfiguration.RequestClient.Request<Balance>(HttpMethod.Get, headers, url);
            return balance;
        }
    }
}
