namespace XenditExample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleCreateEWalletCharge
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            Dictionary<string, string> channelProperties = new Dictionary<string, string>();
            channelProperties.Add("success_redirect_url", "https://redirect.me/payment");

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("reference_id", "demo-reference-id");
            parameter.Add("currency", "IDR");
            parameter.Add("amount", 1000);
            parameter.Add("checkout_method", "ONE_TIME_PAYMENT");
            parameter.Add("channel_code", "ID_SHOPEEPAY");
            parameter.Add("channel_properties", channelProperties);

            try
            {
                EWalletCharge eWalletCharge1 = await EWalletCharge.Create(parameter);
                Console.WriteLine(eWalletCharge1);

                EWalletCharge eWalletCharge2 = await EWalletCharge.Create("demo-reference-id", "IDR", 1000, "ONE_TIME_PAYMENT", "ID_SHOPEEPAY", channelProperties, null, null, null, null);
                Console.WriteLine(eWalletCharge2);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}