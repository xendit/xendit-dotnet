namespace Xendit.net.Model
{
    using System.Numerics;
    using System.Text.Json.Serialization;

    public class AvailableBankInvoice
    {
        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("collection_type")]
        public string CollectionType { get; set; }

        [JsonPropertyName("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [JsonPropertyName("transfer_amount")]
        public BigInteger TransferAmount { get; set; }

        [JsonPropertyName("bank_branch")]
        public string BankBranch { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }
    }
}
