namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CustomerType
    {
        Unknown,

        [EnumMember(Value = "INDIVIDUAL")]
        Individual,

        [EnumMember(Value = "BUSINESS")]
        Business,
    }
}
