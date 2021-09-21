namespace Xendit.net.Model.VirtualAccount
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class VirtualAccountPaymentClient
    {
        private string apiKey;
        private string baseUrl;
        private INetworkClient requestClient;

        public VirtualAccountPaymentClient(string apiKey = null, string baseUrl = null, INetworkClient requestClient = null)
        {
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;
            this.requestClient = requestClient;
        }

        /// <summary>
        /// Get Virtual Account payment based on its payment ID.
        /// </summary>
        /// <param name="paymentId">ID of the payment to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account-payment"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountPaymentResponse"/>.</returns>
        public async Task<VirtualAccountPaymentResponse> Get(string paymentId, HeaderParameter? headers = null)
        {
            return await GetRequest(paymentId, headers);
        }

        private async Task<VirtualAccountPaymentResponse> GetRequest(string paymentId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/callback_virtual_account_payments/payment_id=", paymentId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<VirtualAccountPaymentResponse>(HttpMethod.Get, headers, url, this.apiKey, this.baseUrl);
        }
    }
}
