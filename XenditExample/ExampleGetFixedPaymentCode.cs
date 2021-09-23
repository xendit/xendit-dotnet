namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleGetFixedPaymentCode
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                FixedPaymentCode fixedPaymentCode = await RetailOutlet.GetPaymentCode("example_payment_code_id");
                Console.WriteLine(fixedPaymentCode);

                FixedPaymentCode[] fixedPaymentCodes = await RetailOutlet.GetPayments("example_payment_code_id");
                Console.WriteLine(fixedPaymentCodes);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
