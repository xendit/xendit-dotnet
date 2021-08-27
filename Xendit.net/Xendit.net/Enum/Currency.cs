namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Currency
    {
        Unknown,

        [EnumMember(Value = "IDR")]
        IDR,

        [EnumMember(Value = "PHP")]
        PHP,
    }
}
