namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model.Balance;
    using Xendit.net.Network;

    class ExampleGetBalance
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";
            
            try
            {
                BalanceResponse balance = await Balance.Get();
                Console.WriteLine(balance.Balance);

                BalanceResponse balanceWithType = await Balance.Get(BalanceAccountType.Holding);
                Console.WriteLine(balanceWithType.Balance)
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
