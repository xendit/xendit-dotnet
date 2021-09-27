namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.PaymentCode;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleGetPaymentMethod
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                PaymentMethodResponse[] paymentMethods = await PaymentMethod.Get("customer_id");
                Console.WriteLine(paymentMethods);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
