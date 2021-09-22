namespace Xendit.net.Model.Balance
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class BalanceClient : BaseClient
    {
        public BalanceClient(string apiKey = null, string baseUrl = null, INetworkClient requestClient = null)
            : base(apiKey, baseUrl, requestClient)
        {
        }

        /// <summary>
        /// Get balance from your account based on given account type.
        /// </summary>
        /// <param name="accountType">Selected balance type <see cref="BalanceAccountType"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-balance"/>.</param>
        /// <returns>A Task of <see cref="BalanceResponse"/>.</returns>
        public async Task<BalanceResponse> Get(BalanceAccountType? accountType = null, HeaderParameter? headers = null)
        {
            return await this.GetBalanceRequest(accountType, headers);
        }

        private async Task<BalanceResponse> GetBalanceRequest(BalanceAccountType? accountType, HeaderParameter? headers)
        {
            string url = "/balance";
            if (accountType != null)
            {
                string accountTypeParam = JsonSerializer.Deserialize<string>(JsonSerializer.Serialize(accountType));
                url = string.Format("{0}{1}{2}", url, "?account_type=", accountTypeParam);
            }

            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<BalanceResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
