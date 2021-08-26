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
                CustomerAddress addresses = new CustomerAddress
                {
                    Country = "ID",
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
                    Addresses = new CustomerAddress[] { addresses },
                };

                CustomerNotificationPreferenceInvoice preference = new CustomerNotificationPreferenceInvoice
                {
                    InvoicePaid = new string[] { "email" }
                };

                ItemInvoice item = new ItemInvoice
                {
                    Name = "shoes",
                    Quantity = 1,
                    Price = 100,
                };

                FeeInvoice fee = new FeeInvoice
                {
                    Type = "ADMIN",
                    Value = 200,
                };

                InvoiceBody parameter = new InvoiceBody
                {
                    ExternalId = "demo-1475804036622",
                    Amount = 1000,
                    Customer = customer,
                    CustomerNotificationPreference = preference,
                    Items = new ItemInvoice[] { item },
                    Fees = new FeeInvoice[] { fee },
                    InvoiceDuration = 86400,
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
