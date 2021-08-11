namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;
    using System.Collections.Generic;

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
                Dictionary<string, string> headers = new Dictionary<string, string>()
                {
                    { "API-Version", "2020-05-19" }
                };

                Customer[] customer = await Customer.GetByReferenceId(headers, "example_reference_id");

                Console.WriteLine(customer[0]);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}