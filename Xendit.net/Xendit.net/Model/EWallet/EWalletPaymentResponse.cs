namespace Xendit.net.Model.EWallet
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class EWalletPaymentResponse
    {
        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("transaction_date")]
        public string TransactionDate { get; set; }

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("payment_timestamp")]
        public string PaymentTimestamp { get; set; }

        [JsonPropertyName("expired_at")]
        public string ExpiredAt { get; set; }

        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("ewallet_transaction_id")]
        public string EWalletTransactionId { get; set; }

        [JsonPropertyName("status")]
        public EWalletEnum.Status Status { get; set; }

        [JsonPropertyName("ewallet_type")]
        public EWalletEnum.PaymentType EWalletType { get; set; }
    }
}
