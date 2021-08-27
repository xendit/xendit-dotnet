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
    }
}
