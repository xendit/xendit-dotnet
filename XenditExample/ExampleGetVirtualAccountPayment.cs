namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleGetVirtualAccountPayment
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            string virtualAccountPaymentId = "random_1560763705544";

            try
            {
                VirtualAccountPayment virtualAccountPayment = await VirtualAccountPayment.Get(virtualAccountPaymentId);

                Console.WriteLine(virtualAccountPayment);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}