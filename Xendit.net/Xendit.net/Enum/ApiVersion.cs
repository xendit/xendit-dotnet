namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ApiVersion
    {
        Unknown,

        [EnumMember(Value = "2020-10-31")]
        Version20201031,

        [EnumMember(Value = "2020-05-19")]
        Version20200519,
    }
}
