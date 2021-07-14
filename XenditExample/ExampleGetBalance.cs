using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xendit.net.Model;
using Xendit.net;
using Xendit.net.Network;

namespace XenditExample
{
    class ExampleGetBalance
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";
            
            Balance balance = await Balance.Get();
            Console.WriteLine(balance.Value);
        }
    }
}
