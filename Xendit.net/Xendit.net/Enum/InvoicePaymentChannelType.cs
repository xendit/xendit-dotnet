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
        BCA,

        [EnumMember(Value = "BNI")]
        BNI,

        [EnumMember(Value = "BNI_SYARIAH")]
        BNISyariah,

        [EnumMember(Value = "BRI")]
        BRI,

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
        OVO,

        [EnumMember(Value = "DANA")]
        Dana,

        [EnumMember(Value = "SHOPEEPAY")]
        ShopeePay,

        [EnumMember(Value = "LINKAJA")]
        LinkAja,

        [EnumMember(Value = "GRABPAY")]
        GrabPay,

        [EnumMember(Value = "GCASH")]
        GCash,

        [EnumMember(Value = "PAYMAYA")]
        PayMaya,

        [EnumMember(Value = "QRIS")]
        QRIS,

        [EnumMember(Value = "DD_BRI")]
        DirectDebitBRI,

        [EnumMember(Value = "DD_BPI")]
        DirectDebitBPI,

        [EnumMember(Value = "DD_UBP")]
        DirectDebitUBP,
    }
}
