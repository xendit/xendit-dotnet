namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum EwalletType
    {
        Unknown,

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
    }
}
