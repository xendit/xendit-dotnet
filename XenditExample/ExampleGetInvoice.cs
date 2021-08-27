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
    using Xendit.net.Network;

    class ExampleGetInvoice
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                string invoiceId = "invoice_id";
                Invoice invoice = await Invoice.GetById(invoiceId);
                Console.WriteLine(invoice);

                ListInvoiceParameter parameter = new ListInvoiceParameter
                {
                    Limit = 1,
                    ClientTypes = new InvoiceClientType[] { InvoiceClientType.ApiGateway, InvoiceClientType.Dashboard }
                };

                Invoice[] invoiceArray = await Invoice.GetAll(parameter);
                Console.WriteLine(invoiceArray);

                Invoice[] invoicesWithoutParams = await Invoice.GetAll(null);
                Console.WriteLine(invoicesWithoutParams);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
