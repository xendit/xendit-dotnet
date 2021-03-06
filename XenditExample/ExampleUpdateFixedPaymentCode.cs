namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.PaymentCode;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleUpdateFixedPaymentCode
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                UpdateFixedPaymentCodeParameter parameter = new UpdateFixedPaymentCodeParameter
                {
                    CustomerName = "Rika Sutanto",
                    Amount = 100,
                    Currency = Currency.PHP,
                    Description = "Example updated payment code",
                };

                FixedPaymentCode fixedPaymentCode = await RetailOutlet.UpdatePaymentCode(parameter, "example_payment_code_id");
                Console.WriteLine(fixedPaymentCode);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
