namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum InvoiceStatus
    {
        Unknown,

        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "PAID")]
        Paid,

        [EnumMember(Value = "SETTLED")]
        Settled,

        [EnumMember(Value = "EXPIRED")]
        Expired,
    }
}
