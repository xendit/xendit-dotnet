namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Country
    {
        Unknown,

        [EnumMember(Value = "ID")]
        Indonesia,

        [EnumMember(Value = "PH")]
        Philippines,
    }
}
