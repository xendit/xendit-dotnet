namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class VirtualAccountPayment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; }

        [JsonPropertyName("callback_virtual_account_id")]
        public string CallbackVirtualAccountId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("merchant_code")]
        public string MerchantCode { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("transaction_timestamp")]
        public string TransactionTimestamp { get; set; }

        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// Get Virtual Account payment based on its payment ID.
        /// </summary>
        /// <param name="paymentId">ID of the payment to retrieve.</param>
        /// <returns>A Task of Virtual Account Payment model.</returns>
        public static async Task<VirtualAccountPayment> Get(string paymentId)
        {
            return await Get(new Dictionary<string, string>(), paymentId);
        }

        /// <summary>
        /// Get Virtual Account payment based on its payment ID with custom header.
        /// </summary>
        /// <param name="headers">Custom headers. e.g. "for-user-id".</param>
        /// <param name="paymentId">ID of the payment to retrieve.</param>
        /// <returns>A Task of Virtual Account Payment model.</returns>
        public static async Task<VirtualAccountPayment> Get(Dictionary<string, string> headers, string paymentId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/callback_virtual_account_payments/payment_id=", paymentId);

            var virtualAccountPayment = await XenditConfiguration.RequestClient.Request<VirtualAccountPayment>(HttpMethod.Get, headers, url, null);
            return virtualAccountPayment;
        }
    }
}
