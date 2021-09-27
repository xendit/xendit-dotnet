namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Exception;
    using Xendit.net.Model;
    using Xendit.net.Model.LinkedAccountToken;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    class ExampleUnbindLinkedAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                string linkedAccountTokenId = "linked-account-token-id";
                UnbindedLinkedAccount unbindedLinkedAccount = await LinkedAccountToken.Unbind(linkedAccountTokenId);
                Console.WriteLine(unbindedLinkedAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
