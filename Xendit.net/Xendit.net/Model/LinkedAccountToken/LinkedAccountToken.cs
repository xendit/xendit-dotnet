namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class LinkedAccountToken
    {
        /// <summary>
        /// Get accessible accounts by linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#retrieve-accessible-accounts-by-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="AccessibleLinkedAccountTokenResponse[]"/>.</returns>
        public static async Task<AccessibleLinkedAccountTokenResponse[]> Get(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await GetRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Initialize linked account tokenization.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InitializedLinkedAccountTokenParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#initialize-linked-account-tokenization"/>.</param>
        /// <returns>A Task of <see cref="InitializedLinkedAccountTokenResponse"/>.</returns>
        public static async Task<InitializedLinkedAccountTokenResponse> Initialize(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers = null)
        {
            return await InitializeRequest(parameter, headers);
        }

        /// <summary>
        /// Unlinks or unbinds a successful linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#unbind-a-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="UnbindedLinkedAccountTokenResponse"/>.</returns>
        public static async Task<UnbindedLinkedAccountTokenResponse> Unbind(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await UnbindRequest(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Validate OTP for linked account token.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="ValidatedLinkedAccountTokenResponse"/>.</returns>
        public static async Task<ValidatedLinkedAccountTokenResponse> ValidateOtp(string otpCode, string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            return await ValidateOtpRequest(otpCode, linkedAccountTokenId, headers);
        }

        private static async Task<AccessibleLinkedAccountTokenResponse[]> GetRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Get(linkedAccountTokenId, headers);
        }

        private static async Task<InitializedLinkedAccountTokenResponse> InitializeRequest(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Initialize(parameter, headers);
        }

        private static async Task<UnbindedLinkedAccountTokenResponse> UnbindRequest(string linkedAccountTokenId, HeaderParameter? headers)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Unbind(linkedAccountTokenId, headers);
        }

        private static async Task<ValidatedLinkedAccountTokenResponse> ValidateOtpRequest(string otpCode, string linkedAccountTokenId, HeaderParameter? headers)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.ValidateOtp(otpCode, linkedAccountTokenId, headers);
        }
    }
}
