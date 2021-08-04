namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleCreateInvoice
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
                parameter.Add("external_id", "demo-1");
                parameter.Add("amount", 1000);
                Invoice invoice = await Invoice.Create(parameter);
                Console.WriteLine(invoice);

                Invoice invoice2 = await Invoice.Create("demo-1", 1000);
                Console.WriteLine(invoice2);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
