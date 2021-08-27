namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum InvoiceClientType
    {
        Unknown,

        [EnumMember(Value = "API_GATEWAY")]
        ApiGateway,

        [EnumMember(Value = "DASHBOARD")]
        Dashboard,

        [EnumMember(Value = "INTEGRATION")]
        Integration,

        [EnumMember(Value = "ON_DEMAND")]
        OnDemand,

        [EnumMember(Value = "RECURRING")]
        Recurring,

        [EnumMember(Value = "MOBILE")]
        Mobile,
    }
}
