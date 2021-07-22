namespace Xendit.net.Network
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface INetworkClient
    {
        Task<T> Request<T>(HttpMethod httpMethod, Dictionary<string, string> headers, string url, Dictionary<string, object> requestBody);
    }
}
