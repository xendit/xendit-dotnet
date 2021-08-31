namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum PaymentMethodAccountType1
    {
        Unknown,

        [EnumMember(Value = "DEBIT_CARD")]
        DebitCard,

        [EnumMember(Value = "BANK_REDIRECT")]
        BankRedirect,

        [EnumMember(Value = "BANK_ACCOUNT")]
        BankAccount,
    }
}
