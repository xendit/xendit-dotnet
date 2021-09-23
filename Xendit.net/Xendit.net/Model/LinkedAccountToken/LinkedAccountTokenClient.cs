namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class LinkedAccountTokenClient : BaseClient
    {
        public LinkedAccountTokenClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Get accessible accounts by linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#retrieve-accessible-accounts-by-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="AccessibleLinkedAccountTokenResponse[]"/>.</returns>
        public async Task<AccessibleLinkedAccountTokenResponse[]> Get(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await this.GetRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Initialize linked account tokenization.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InitializedLinkedAccountTokenParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#initialize-linked-account-tokenization"/>.</param>
        /// <returns>A Task of <see cref="InitializedLinkedAccountTokenResponse"/>.</returns>
        public async Task<InitializedLinkedAccountTokenResponse> Initialize(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers = null)
        {
            return await this.InitializeRequest(parameter, headers);
        }

        /// <summary>
        /// Unlinks or unbinds a successful linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#unbind-a-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="UnbindedLinkedAccountTokenResponse"/>.</returns>
        public async Task<UnbindedLinkedAccountTokenResponse> Unbind(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await this.UnbindRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Validate OTP for linked account token.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="ValidatedLinkedAccountTokenResponse"/>.</returns>
        public async Task<ValidatedLinkedAccountTokenResponse> ValidateOtp(string otpCode, string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>()
            {
                { "otp_code", otpCode },
            };

            return await this.ValidateOtpRequest(parameter, linkedAccountTokenId, headers);
        }

        private async Task<AccessibleLinkedAccountTokenResponse[]> GetRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/linked_account_tokens/", linkedAccountTokenId, "/accounts");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<AccessibleLinkedAccountTokenResponse[]>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }

        private async Task<InitializedLinkedAccountTokenResponse> InitializeRequest(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers)
        {
            string url = "/linked_account_tokens/auth";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountTokenResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }

        private async Task<UnbindedLinkedAccountTokenResponse> UnbindRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/linked_account_tokens/", linkedAccountTokenId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<UnbindedLinkedAccountTokenResponse>(HttpMethod.Delete, headers, url, this.apiKey, this.baseUrl);
        }

        private async Task<ValidatedLinkedAccountTokenResponse> ValidateOtpRequest(Dictionary<string, string> parameter, string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/linked_account_tokens/", linkedAccountTokenId, "/validate_otp");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<Dictionary<string, string>, ValidatedLinkedAccountTokenResponse>(HttpMethod.Post, headers, url, this.apiKey, this.baseUrl, parameter);
        }
    }
}
