namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class AvailableBankInvoice
    {
        [JsonPropertyName("bank_code")]
        public BankCode BankCode { get; set; }

        [JsonPropertyName("collection_type")]
        public string CollectionType { get; set; }

        [JsonPropertyName("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [JsonPropertyName("transfer_amount")]
        public long TransferAmount { get; set; }

        [JsonPropertyName("bank_branch")]
        public string BankBranch { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }
    }
}
