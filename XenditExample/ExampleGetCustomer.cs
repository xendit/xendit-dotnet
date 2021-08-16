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
                Customer[] customer1 = await Customer.GetByReferenceId("example_reference_id_1");
                Console.WriteLine(customer1[0]);

                Customer customer2 = await Customer.GetByReferenceIdNew("example_reference_id_2");
                Console.WriteLine(customer2.Data[0]);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
