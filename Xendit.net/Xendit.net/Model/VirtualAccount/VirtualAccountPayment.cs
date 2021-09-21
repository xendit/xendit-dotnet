namespace Xendit.net.Model.VirtualAccount
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class VirtualAccountPayment
    {
        /// <summary>
        /// Get Virtual Account payment based on its payment ID.
        /// </summary>
        /// <param name="paymentId">ID of the payment to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account-payment"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountPaymentResponse"/>.</returns>
        public static async Task<VirtualAccountPaymentResponse> Get(string paymentId, HeaderParameter? headers = null)
        {
            return await GetRequest(paymentId, headers);
        }

        private static async Task<VirtualAccountPaymentResponse> GetRequest(string paymentId, HeaderParameter? headers)
        {
            VirtualAccountPaymentClient client = new VirtualAccountPaymentClient();
            return await client.Get(paymentId, headers);
        }
    }
}
