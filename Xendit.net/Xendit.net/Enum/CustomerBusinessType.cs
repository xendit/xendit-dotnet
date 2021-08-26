namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    public enum CustomerBusinessType
    {
        Unknown,

        [EnumMember(Value = "CORPORATION")]
        Corporation,

        [EnumMember(Value = "SOLE_PROPRIETOR")]
        SoleProprietor,

        [EnumMember(Value = "PARTNERSHIP")]
        Partnership,

        [EnumMember(Value = "COOPERATIVE")]
        Cooperative,

        [EnumMember(Value = "TRUST")]
        Trust,

        [EnumMember(Value = "NON_PROFIT")]
        NonProfit,

        [EnumMember(Value = "GOVERNMENT")]
        Government,
    }
}
