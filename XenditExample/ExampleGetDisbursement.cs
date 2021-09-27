namespace XenditExample
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.Disbursement;
    using Xendit.net.Network;

    class ExampleGetDisbursement
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                string disbursementId = "disbursement_id";
                DisbursementResponse disbursement = await Disbursement.GetById(disbursementId);
                Console.WriteLine(disbursement);

                string externalId = "external_id";
                DisbursementResponse[] disbursements = await Disbursement.GetByExternalId(externalId);
                Console.WriteLine(disbursements[0]);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
