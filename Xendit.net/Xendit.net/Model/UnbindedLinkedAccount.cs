namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class UnbindedLinkedAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Unlinks or unbinds a successful linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <seealso href="https://developers.xendit.co/api-reference/#unbind-a-linked-account-token"/>.</param>
        /// <returns>A Task of Accessible Linked Account model <seealso cref="AccessibleLinkedAccount"/>.</returns>
        public static async Task<UnbindedLinkedAccount> Unbind(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await UnbindRequest(linkedAccountTokenId, headers);
        }

        private static async Task<UnbindedLinkedAccount> UnbindRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/linked_account_tokens/", linkedAccountTokenId);
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, UnbindedLinkedAccount>(HttpMethod.Delete, headers, url, null);
        }
    }
}
