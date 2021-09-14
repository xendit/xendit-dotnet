namespace XenditExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleCreateVirtualAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                VirtualAccountParameter parameter = new VirtualAccountParameter
                { 
                    ExternalId = "my_external_id",
                    BankCode = VirtualAccountEnum.BankCode.Bni,
                    Name = "John Doe",
                    ExpectedAmount = 200000,
                };

                VirtualAccount virtualAccount = await VirtualAccount.Create(parameter);
                Console.WriteLine(virtualAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
