namespace XenditExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleGetAvailableVABank
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                List<AvailableBank> availableBanks = await VirtualAccount.GetAvailableBanks();

                availableBanks.ForEach(bank => Console.WriteLine(bank.Name));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
