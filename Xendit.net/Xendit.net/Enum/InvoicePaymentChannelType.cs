namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum InvoicePaymentChannelType
    {
        Unknown,

        [EnumMember(Value = "CREDIT_CARD")]
        CreditCard,

        [EnumMember(Value = "BCA")]
        Bca,

        [EnumMember(Value = "BNI")]
        Bni,

        [EnumMember(Value = "BNI_SYARIAH")]
        BniSyariah,

        [EnumMember(Value = "BRI")]
        Bri,

        [EnumMember(Value = "MANDIRI")]
        Mandiri,

        [EnumMember(Value = "PERMATA")]
        Permata,

        [EnumMember(Value = "ALFAMART")]
        Alfamart,

        [EnumMember(Value = "INDOMARET")]
        Indomaret,

        [EnumMember(Value = "7ELEVEN")]
        SevenEleven,

        [EnumMember(Value = "OVO")]
        Ovo,

        [EnumMember(Value = "DANA")]
        Dana,

        [EnumMember(Value = "SHOPEEPAY")]
        Shopeepay,

        [EnumMember(Value = "LINKAJA")]
        Linkaja,

        [EnumMember(Value = "GRABPAY")]
        Grabpay,

        [EnumMember(Value = "GCASH")]
        Gcash,

        [EnumMember(Value = "PAYMAYA")]
        Paymaya,

        [EnumMember(Value = "QRIS")]
        Qris,

        [EnumMember(Value = "DD_BRI")]
        DirectDebitBri,

        [EnumMember(Value = "DD_BPI")]
        DirectDebitBpi,

        [EnumMember(Value = "DD_UBP")]
        DirectDebitUbp,
    }
}
