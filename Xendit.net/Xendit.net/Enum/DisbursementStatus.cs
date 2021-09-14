namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DisbursementStatus
    {
        Unknown,

        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "COMPLETED")]
        Completed,

        [EnumMember(Value = "FAILED")]
        Failed,
    }
}
