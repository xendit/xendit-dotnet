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

    class ExampleCreateClosedVirtualAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            Dictionary<string, object> closedVABody = new Dictionary<string, object>();
            closedVABody.Add("external_id", "my_external_id");
            closedVABody.Add("bank_code", "BNI");
            closedVABody.Add("name", "John Doe");
            closedVABody.Add("expected_amount", "200000000");

            Dictionary<string, object> additionalParams = new Dictionary<string, object>();
            additionalParams.Add("expiration_date", "2052-07-12T17:00:00.000Z");

            try
            {
                /**
                 * First option. Create directly from a properly named dictionary key value pair.
                 * Check https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts for field name.
                 */
                VirtualAccount virtualAccount = await VirtualAccount.CreateClosed(closedVABody);

                /**
                 * Second option. Create with individual value of required params.
                 */
                VirtualAccount virtualAccount2 = await VirtualAccount.CreateClosed("my_external_id_2",
                        "PERMATA", "John Doe", 100000);

                /**
                 * Third option. Create with individual value of required params plus added additional params at the end.
                 */
                VirtualAccount virtualAccount3 = await VirtualAccount.CreateClosed("my_external_id_3",
                        "MANDIRI", "John Doe", 100000, additionalParams);

                Console.WriteLine(virtualAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
