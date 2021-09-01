namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum NotificationType
    {
        Unknown,

        [EnumMember(Value = "whatsapp")]
        WhatsApp,

        [EnumMember(Value = "sms")]
        SMS,

        [EnumMember(Value = "email")]
        Email,
    }
}
