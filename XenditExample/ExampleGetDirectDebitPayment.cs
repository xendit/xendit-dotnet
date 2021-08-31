namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;
    using Xendit.net.Struct;
    using Xendit.net.Enum;

    class ExampleGetDirectDebitPayment
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                DirectDebitPayment directDebitPayment = await DirectDebitPayment.GetById("direct_debit_id");
                Console.WriteLine(directDebitPayment);

                DirectDebitPayment[] directDebitPayments = await DirectDebitPayment.GetByReferenceId("reference_id");
                Console.WriteLine(directDebitPayments);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
