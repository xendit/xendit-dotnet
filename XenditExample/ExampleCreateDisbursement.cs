namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Enum;
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
                DisbursementParameter parameter = new DisbursementParameter
                {
                    ExternalId = "disb-1475459775872",
                    BankCode = DisbursementChannelCode.Bca,
                    AccountHolderName = "MICHAEL CHEN",
                    AccountNumber = "1234567890",
                    Description = "Reimbursement for shoes",
                    Amount = 1000,
                };

                Disbursement disbursement = await Disbursement.Create(parameter);
                Console.WriteLine(disbursement1);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
