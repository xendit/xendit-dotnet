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

    class ExampleCreateDirectDebitPayment
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                DirectDebitPaymentParameter directDebitPaymentParameter = new DirectDebitPaymentParameter
                {
                    ReferenceId = "reference-id",
                    PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
                    Currency = Currency.IDR,
                    Amount = 10000,
                    CallbackUrl = "https://callback-url.com/",
                    EnableOtp = true,
                    Description = "Example Description",
                    Device = new LinkedAccountDevice
                    {
                        Id = "device-id",
                        IpAddress = "255.255.255.255",
                        UserAgent = "App",
                        Imei = "imei-example",
                        AdId = "ad-id",
                    },
                    Metadata = null,
                    Basket = new BasketItem[]
                    {
                        new BasketItem { Name = "Black shoes", Type = "goods", Price = 2000, Quantity = 1 },
                        new BasketItem { Name = "Blue shirt", Type = "apparel", Price = 2000, Quantity = 1 },
                    },
                };

                string idempotencyKey = "fa9b53a1-f81a-47ff-8fde-b2eec3546b66";

                DirectDebitPayment directDebitPayment = await DirectDebitPayment.Create(directDebitPaymentParameter, idempotencyKey);
                Console.WriteLine(directDebitPayment);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
