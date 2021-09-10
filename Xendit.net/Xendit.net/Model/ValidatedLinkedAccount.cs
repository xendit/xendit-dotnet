namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Enum;

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
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <seealso href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/>.</param>
        /// <returns>A Task of Validated Linked Account model <seealso cref="ValidatedLinkedAccount"/>.</returns>
        public static async Task<ValidatedLinkedAccount> ValidateOTP(string otpCode, string linkedAccountTokenId, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            Dictionary<string, string> parameter = new Dictionary<string, string>()
            {
                { "otp_code", otpCode },
            };

            return await ValidateOTPRequest(parameter, linkedAccountTokenId, headers);
        }

        private static async Task<ValidatedLinkedAccount> ValidateOTPRequest(Dictionary<string, string> parameter, string linkedAccountTokenId, Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}{2}{3}", XenditConfiguration.ApiUrl, "/linked_account_tokens/", linkedAccountTokenId, "/validate_otp");
            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, ValidatedLinkedAccount>(HttpMethod.Post, headers, url, parameter);
        }
    }
}
