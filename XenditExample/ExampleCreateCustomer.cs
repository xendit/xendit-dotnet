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

    class ExampleCreateCustomer
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "API-Version", "2020-05-19" },
            };

            try
            {
                Customer customer1 = await Customer.Create(headers, "example_reference_id", "John", "+6287774441111", "john@email.com");
                Console.WriteLine(customer1);

                Dictionary<string, object> parameter = new Dictionary<string, object>();
                parameter.Add("reference_id", "example_reference_id");
                parameter.Add("given_names", "John");
                parameter.Add("mobile_number", "+6287774441111");
                parameter.Add("email", "john@email.com");

                Customer customer2 = await Customer.Create(headers, parameter);
                Console.WriteLine(customer2);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}