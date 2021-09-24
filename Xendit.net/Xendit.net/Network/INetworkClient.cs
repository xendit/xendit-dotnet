namespace Xendit.net.Network
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public interface INetworkClient
    {
        Task<TResponse> Request<TResponse>(HttpMethod httpMethod, string url, string apiKey, string baseUrl, HeaderParameter? headers);

        Task<TResponse> Request<TBody, TResponse>(HttpMethod httpMethod, string url, string apiKey, string baseUrl, TBody requestBody, HeaderParameter? headers);
    }
}
