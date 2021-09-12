namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class AccessibleLinkedAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("type")]
        public LinkedAccountEnum.Type Type { get; set; }

        [JsonPropertyName("properties")]
        public LinkedAccountProperties Properties { get; set; }

        /// <summary>
        /// Get accessible accounts by linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#retrieve-accessible-accounts-by-linked-account-token"/>.</param>
        /// <returns>A Task of Accessible Linked Account model <seealso cref="AccessibleLinkedAccount"/>.</returns>
        public static async Task<AccessibleLinkedAccount[]> Get(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await GetRequest(linkedAccountTokenId, headers);
        }

        private static async Task<AccessibleLinkedAccount[]> GetRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/linked_account_tokens/", linkedAccountTokenId, "/accounts");
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, AccessibleLinkedAccount[]>(HttpMethod.Get, headers, url, null);
        }
    }
}
