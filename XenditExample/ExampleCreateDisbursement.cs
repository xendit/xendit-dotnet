namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Network;

    class ExampleCreateDisbursement
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>()
                {
                    { "external_id", "disb-1475459775872" },
                    { "bank_code", "BCA" },
                    { "account_holder_name", "MICHAEL CHEN" },
                    { "account_number", "1234567890" },
                    { "description", "Reimbursement for shoes" },
                    { "amount", 1 },
                };
                Disbursement disbursement1 = await Disbursement.Create(parameter);
                Console.WriteLine(disbursement1);

                Disbursement disbursement2 = await Disbursement.Create("disb-1475459775872", "BCA", "MICHAEL", "1234567890", "description", 1);
                Console.WriteLine(disbursement2);

                Dictionary<string, object> additionalParameter = new Dictionary<string, object>()
                {
                    { "email_to", "[\"somebody@email.com\"]" }
                };

                Disbursement disbursement3 = await Disbursement.Create("disb-1475459775872", "BCA", "MICHAEL", "1234567890", "description", 1, additionalParameter);
                Console.WriteLine(disbursement3);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
