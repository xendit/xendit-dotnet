namespace Xendit.net.Network
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface INetworkClient
    {
        Task<TResponse> Request<TResponse>(HttpMethod httpMethod, Dictionary<string, string> headers, string url);

        Task<TResponse> Request<TBody, TResponse>(HttpMethod httpMethod, Dictionary<string, string> headers, string url, TBody requestBody);
    }
}
