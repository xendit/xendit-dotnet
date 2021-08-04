namespace XenditExample
{
	using System;
	using System.Threading.Tasks;
	using System.Net.Http;
	using Xendit.net;
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

				Dictionary<string, object> parameter = new Dictionary<string, object>();
				parameter.Add("limit", 1);
				parameter.Add("statutes", "[\"PENDING\",\"EXPIRED\"]");
				Invoice[] invoiceArray = await Invoice.GetAll(parameter);
				Console.WriteLine(invoiceArray);
			}
			catch (XenditException e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}
