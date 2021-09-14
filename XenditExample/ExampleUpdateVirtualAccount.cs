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
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("is_single_use", true);

                VirtualAccount virtualAccount = await VirtualAccount.Update("virtual_account_id", parameter);
                Console.WriteLine(virtualAccount.IsSingleUse);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}