namespace Xendit.net.Model.Balance
{
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Balance
    {
        /// <summary>
        /// Get balance from your account based on given account type.
        /// </summary>
        /// <param name="accountType">Selected balance type <see cref="BalanceAccountType"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-balance"/>.</param>
        /// <returns>A Task of <see cref="BalanceResponse"/>.</returns>
        public static async Task<BalanceResponse> Get(BalanceAccountType? accountType = null, HeaderParameter? headers = null)
        {
            BalanceClient client = new BalanceClient();
            return await client.Get(accountType, headers);
        }
    }
}
