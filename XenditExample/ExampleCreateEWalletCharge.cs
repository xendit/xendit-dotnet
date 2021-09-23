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

    class ExampleCreateEWalletCharge
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                EWalletChargeParameter parameter = new EWalletChargeParameter
                {
                    ReferenceId = "demo-reference-id",
                    Currency = Currency.IDR,
                    Amount = 1000,
                    CheckoutMethod = EWalletEnum.CheckoutMethod.OneTimePayment,
                    ChannelCode = EWalletEnum.ChannelCode.IdOvo,
                    ChannelProperties = new EWalletChargeProperties
                    {
                        MobileNumber = "+628123123123",
                    },
                };

                EWalletChargeResponse eWalletCharge = await EWalletCharge.Create(parameter);
                Console.WriteLine(eWalletCharge);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
