namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class ValidatedLinkedAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("channel_code")]
        public LinkedAccountEnum.ChannelCode ChannelCode { get; set; }

        [JsonPropertyName("status")]
        public LinkedAccountEnum.Status Status { get; set; }

        /// <summary>
        /// Validate OTP for linked account token.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="ValidatedLinkedAccountParameter"/>.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id". <seealso href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/></param>
        /// <returns>A Task of Validated Linked Account model.</returns>
        public static async Task<ValidatedLinkedAccount> ValidateOTP(ValidatedLinkedAccountParameter parameter, string linkedAccountTokenId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            return await ValidateOTPRequest(parameter, linkedAccountTokenId, headers);
        }

        private static async Task<ValidatedLinkedAccount> ValidateOTPRequest(ValidatedLinkedAccountParameter parameter, string linkedAccountTokenId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/linked_account_tokens/", linkedAccountTokenId, "/validate_otp");
            return await XenditConfiguration.RequestClient.Request<ValidatedLinkedAccountParameter, ValidatedLinkedAccount>(HttpMethod.Post, headers, url, parameter);
        }
    }
}
