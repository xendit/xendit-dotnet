namespace XenditExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.EWallet;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleGetEWalletPayment
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                EWalletPaymentResponse eWalletPayment = await EWalletPayment.Get("external-id", EWalletEnum.PaymentType.Ovo);
                Console.WriteLine(eWalletPayment);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
