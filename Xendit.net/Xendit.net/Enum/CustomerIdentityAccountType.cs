namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CustomerIdentityAccountType
    {
        Unknown,

        [EnumMember(Value = "BANK_ACCOUNT")]
        BankAccount,

        [EnumMember(Value = "EWALLET")]
        Ewallet,

        [EnumMember(Value = "CREDIT_CARD")]
        CreditCard,

        [EnumMember(Value = "PAY_LATER")]
        PayLater,

        [EnumMember(Value = "OTC")]
        Otc,

        [EnumMember(Value = "QR_CODE")]
        QrCode,

        [EnumMember(Value = "SOCIAL_MEDIA")]
        SocialMedia,
    }
}
