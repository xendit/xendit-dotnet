namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    public enum CustomerGender
    {
        Unknown,

        [EnumMember(Value = "MALE")]
        Male,

        [EnumMember(Value = "FEMALE")]
        Female,

        [EnumMember(Value = "OTHER")]
        Other,
    }
}
