namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.Customer;
    using Xendit.net.Network;

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
                CustomerResponse customerDefault = await Customer.Get("demo_11212145");
                Console.WriteLine(customerDefault);

                CustomerResponse customerCustomVersion = await Customer.Get("demo_11212144", version: ApiVersion.Version20200519);
                Console.WriteLine(customerCustomVersion);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
