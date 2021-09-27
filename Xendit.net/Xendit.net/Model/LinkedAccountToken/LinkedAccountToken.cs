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
        /// <returns>A Task of <see cref="AccessibleLinkedAccountToken[]"/>.</returns>
        public static async Task<AccessibleLinkedAccountToken[]> Get(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Get(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Initialize linked account tokenization.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InitializedLinkedAccountTokenParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#initialize-linked-account-tokenization"/>.</param>
        /// <returns>A Task of <see cref="InitializedLinkedAccountToken"/>.</returns>
        public static async Task<InitializedLinkedAccountToken> Initialize(InitializedLinkedAccountTokenParameter parameter, HeaderParameter? headers = null)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Initialize(parameter, headers);
        }

        /// <summary>
        /// Unlinks or unbinds a successful linked account token.
        /// </summary>
        /// <param name="linkedAccountTokenId">Linked account token `id` received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#unbind-a-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="UnbindedLinkedAccountToken"/>.</returns>
        public static async Task<UnbindedLinkedAccountToken> Unbind(string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.Unbind(linkedAccountTokenId, headers);
        }

        /// <summary>
        /// Validate OTP for linked account token.
        /// </summary>
        /// <param name="otpCode">OTP received by the customer from the partner bank for account linking.</param>
        /// <param name="linkedAccountTokenId">Linked account token id received from Initialize Account Authorization.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#validate-otp-for-linked-account-token"/>.</param>
        /// <returns>A Task of <see cref="ValidatedLinkedAccountToken"/>.</returns>
        public static async Task<ValidatedLinkedAccountToken> ValidateOtp(string otpCode, string linkedAccountTokenId, HeaderParameter? headers = null)
        {
            LinkedAccountTokenClient client = new LinkedAccountTokenClient();
            return await client.ValidateOtp(otpCode, linkedAccountTokenId, headers);
        }
    }
}
