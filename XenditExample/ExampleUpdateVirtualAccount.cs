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
    using Xendit.net.Struct;

    class ExampleUpdateVirtualAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                UpdateVirtualAccountParameter parameter = new UpdateVirtualAccountParameter
                {
                    IsSingleUse = true,
                    ExpectedAmount = 20000,
                };

                VirtualAccountResponse virtualAccount = await VirtualAccount.Update(parameter, "virtual_account_id");
                Console.WriteLine(virtualAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
