namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Struct;
    using Xendit.net.Enum;

    public class InitializedLinkedAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("authorizer_url")]
        public string AuthorizerUrl { get; set; }

        [JsonPropertyName("status")]
        public LinkedAccountEnum.Status Status { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Initialize linked account tokenization.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InitializedLinkedAccountParameter"/>.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#initialize-linked-account-tokenization"/></param>
        /// <returns>A Task of Initialized Linked Account model.</returns>
        public static async Task<InitializedLinkedAccount> Initialize(InitializedLinkedAccountParameter parameter, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await InitializeRequest(parameter, headers);
        }

        private static async Task<InitializedLinkedAccount> InitializeRequest(InitializedLinkedAccountParameter parameter, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/linked_account_tokens/auth");
            return await XenditConfiguration.RequestClient.Request<InitializedLinkedAccountParameter, InitializedLinkedAccount>(HttpMethod.Post, headers, url, parameter);
        }
    }
}
