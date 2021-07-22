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

    class ExampleCreateOpenVirtualAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            Dictionary<string, object> openVAbody = new Dictionary<string, object>();
            openVAbody.Add("external_id", "my_external_id");
            openVAbody.Add("bank_code", "BNI");
            openVAbody.Add("name", "John Doe");

            Dictionary<string, object> additionalParams = new Dictionary<string, object>();
            additionalParams.Add("expiration_date", "2052-07-12T17:00:00.000Z");

            try
            {
                /**
                 * First option. Create directly from a properly named dictionary key value pair.
                 * Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts for field name.
                 */
                VirtualAccount virtualAccount = await VirtualAccount.CreateOpen(openVAbody);

                /**
                 * Second option. Create with individual value of required params.
                 */
                VirtualAccount virtualAccount2 = await VirtualAccount.CreateOpen("my_external_id_2",
                        "PERMATA", "John Doe");

                /**
                 * Third option. Create with individual value of required params plus added additional params at the end.
                 */
                VirtualAccount virtualAccount3 = await VirtualAccount.CreateOpen("my_external_id_3",
                        "MANDIRI", "John Doe", additionalParams);

                Console.WriteLine(virtualAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
