namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum BankCode
    {
        Unknown,

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
    }
}
