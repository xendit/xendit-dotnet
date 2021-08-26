namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;

    class ExampleGetCustomer
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                Customer customerDefault = await Customer.Get("demo_11212145");
                Console.WriteLine(customerDefault);

                Customer customerCustomVersion = await Customer.Get("demo_11212144", version: ApiVersion.Version20200519);
                Console.WriteLine(customerCustomVersion);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
