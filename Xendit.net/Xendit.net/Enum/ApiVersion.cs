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

        [EnumMember(Value = "2020-02-01")]
        Version20200201,

        [EnumMember(Value = "2019-02-04")]
        Version20200204,
    }
}
