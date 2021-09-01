namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum InvoicePaymentMethodType
    {
        Unknown,

        [EnumMember(Value = "CREDIT_CARD")]
        CreditCard,

        [EnumMember(Value = "RETAIL_OUTLET")]
        RetailOutlet,

        [EnumMember(Value = "BANK_TRANSFER")]
        BankTransfer,

        [EnumMember(Value = "EWALLET")]
        EWallet,
    }
}
