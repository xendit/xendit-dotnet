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

    class ExampleCreateEWalletPayment
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                EWalletPaymentParameter parameter = new EWalletPaymentParameter
                {
                    ExternalId = "example-external-id",
                    Amount = 100000,
                    Phone = "08123123123",
                    EWalletType = EWalletEnum.PaymentType.Ovo,
                };

                EWalletPayment eWalletPayment = await EWalletPayment.Create(parameter, apiVersion: ApiVersion.Version20200201);
                Console.WriteLine(eWalletCheWalletPaymentarge);

                EWalletPayment eWalletPayment2 = await EWalletPayment.Create(parameter, apiVersion: ApiVersion.Version20190204);
                Console.WriteLine(eWalletPayment2);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
