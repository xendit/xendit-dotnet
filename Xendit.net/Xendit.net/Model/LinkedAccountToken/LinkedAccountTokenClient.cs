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
        /// <returns>A Task of <see cref="AccessibleLinkedAccountToken[]"/>.</returns>
        public async Task<AccessibleLinkedAccountToken[]> Get(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await this.GetRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Initialize linked account tokenization.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InitializedLinkedAccountTokenParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#initialize-linked-account-tokenization"/>.</param>
        /// <returns>A Task of <see cref="InitializedLinkedAccountToken"/>.</returns>
        public async Task<InitializedLinkedAccountToken> Initialize(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers = null)
        {
            return await this.InitializeRequest(parameter, headers);
        }

        /// <summary>
        /// Unlinks or unbinds a successful linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#unbind-a-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="UnbindedLinkedAccountToken"/>.</returns>
        public async Task<UnbindedLinkedAccountToken> Unbind(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await this.UnbindRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Validate OTP for linked account token.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="ValidatedLinkedAccountToken"/>.</returns>
        public async Task<ValidatedLinkedAccountToken> ValidateOtp(string otpCode, string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>()
            {
                { "otp_code", otpCode },
            };

            return await this.ValidateOtpRequest(parameter, linkedAccountTokenId, headers);
        }

        private async Task<AccessibleLinkedAccountToken[]> GetRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/linked_account_tokens/", linkedAccountTokenId, "/accounts");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<AccessibleLinkedAccountToken[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }

        private async Task<InitializedLinkedAccountToken> InitializeRequest(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers)
        {
            string url = "/linked_account_tokens/auth";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<InitializedLinkedAccountTokenParameter, InitializedLinkedAccountToken>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        private async Task<UnbindedLinkedAccountToken> UnbindRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/linked_account_tokens/", linkedAccountTokenId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<UnbindedLinkedAccountToken>(HttpMethod.Delete, url, this.ApiKey, this.BaseUrl, headers);
        }

        private async Task<ValidatedLinkedAccountToken> ValidateOtpRequest(Dictionary<string, string> parameter, string linkedAccountTokenId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/linked_account_tokens/", linkedAccountTokenId, "/validate_otp");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<Dictionary<string, string>, ValidatedLinkedAccountToken>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }
    }
}
