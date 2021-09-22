namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;
    using Xendit.net.Struct;

    class ExampleCreateInvoice
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                Address addresses = new Address
                {
                    Country = Country.Indonesia,
                    StreetLine1 = "Jalan Makan",
                    StreetLine2 = "Kecamatan Kebayoran Baru",
                    City = "Jakarta Selatan",
                    Province = "Daerah Khusus Ibukota Jakarta",
                    PostalCode = "12345",
                };

                Customer customer = new Customer
                {
                    GivenNames = "John",
                    Email = "john@email.com",
                    MobileNumber = "+6287774441111",
                    Addresses = new Address[] { addresses },
                };

                NotificationPreference preference = new NotificationPreference
                {
                    InvoicePaid = new NotificationType[] { NotificationType.Email }
                };

                ItemInvoice item = new ItemInvoice
                {
                    Name = "shoes",
                    Quantity = 1,
                    Price = 100,
                };

                FeeInvoice fee = new FeeInvoice
                {
                    Type = "name_of_fee_for_internal_reference",
                    Value = 200,
                };

                InvoiceParameter parameter = new InvoiceParameter
                {
                    ExternalId = "external-id",
                    Amount = 1000,
                    Customer = customer,
                    NotificationPreference = preference,
                    Items = new ItemInvoice[] { item },
                    Fees = new FeeInvoice[] { fee },
                    Currency = Currency.IDR,
                    PaymentMethods = new InvoicePaymentChannelType[] { InvoicePaymentChannelType.ShopeePay },
                };

                Invoice invoice = await Invoice.Create(parameter);
                Console.WriteLine(invoice);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
