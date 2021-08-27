namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum RetailOutlet
    {
        Unknown,

        [EnumMember(Value = "ALFAMART")]
        Alfamart,

        [EnumMember(Value = "INDOMARET")]
        Indomaret,

        [EnumMember(Value = "7ELEVEN")]
        SevenEleven,
    }
}
