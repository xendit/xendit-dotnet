namespace XenditCustomerObjectExample
{
    using System;
    using System.Text.Json;
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
        public async Task GetCustomerDefault() {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = System.Environment.GetEnvironmentVariable("XENDIT_API_KEY");

            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                CustomerResponse customerDefault = await Customer.Get("demo_11212162");
                Console.WriteLine(JsonSerializer.Serialize(customerDefault, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task GetCustomerCustomVersion20200519() {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = System.Environment.GetEnvironmentVariable("XENDIT_API_KEY");

            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                CustomerResponse customerCustomVersion = await Customer.Get("demo_11212163", version: ApiVersion.Version20200519);
                Console.WriteLine(JsonSerializer.Serialize(customerCustomVersion, options));
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
