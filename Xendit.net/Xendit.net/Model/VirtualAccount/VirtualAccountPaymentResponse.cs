namespace Xendit.net.Model.VirtualAccount
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class VirtualAccountPaymentResponse
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
        public VirtualAccountEnum.BankCode BankCode { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("transaction_timestamp")]
        public string TransactionTimestamp { get; set; }

        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }
    }
}
