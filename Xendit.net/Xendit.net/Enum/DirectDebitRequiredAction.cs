namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DirectDebitRequiredAction
    {
        Unknown,

        [EnumMember(Value = "VALIDATE_ON_REDIRECT")]
        ValidateOnRedirect,

        [EnumMember(Value = "VALIDATE_OTP")]
        ValidateOtp,

        [EnumMember(Value = null)]
        Null,
    }
}
