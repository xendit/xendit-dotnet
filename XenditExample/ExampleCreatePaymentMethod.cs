namespace ConsoleApp1
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

    class ExampleCreatePaymentMethod
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                PaymentMethodParameter parameter = new PaymentMethodParameter
                {
                    Type = PaymentMethodEnum.AccountType.DebitCard,
                    Properties = new PaymentMethodProperties
                    {
                        Id = "la-052d3e2d-bc4d-4c98-8072-8d232a552299",
                        ChannelCode = PaymentMethodEnum.ChannelCode.DcBRI,
                        Currency = Currency.IDR,
                        CardLastFour = "1234",
                        CardExpiry = "06/24",
                        Description = "Payment Debit Card",
                    },
                    CustomerId = "4b7b6050-0830-440a-903b-37d527dbbaa9",
                };
                PaymentMethod paymentMethod = await PaymentMethod.Create(parameter);
                Console.WriteLine(paymentMethod);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
