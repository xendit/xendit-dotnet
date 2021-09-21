namespace XenditTest.BalanceTest
{
    using Xendit.net.Model.Balance;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly string Url = "/balance";
        internal static readonly string AccountTypeUrl = string.Format("{0}?account_type={1}", Url, "HOLDING");
        internal static readonly string BaseUrl = "https://api.xendit.co";
        internal static readonly string ApiKey = "api-key";
        internal static readonly BalanceResponse ExpectedBalance = new BalanceResponse { Balance = 10000 };
        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };
    }
}
