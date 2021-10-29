namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class VirtualAccountEnum
    {
        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum BankCode
        {
            Unknown,

            [EnumMember(Value = "BCA")]
            Bca,

            [EnumMember(Value = "BNI")]
            Bni,

            [EnumMember(Value = "BRI")]
            Bri,

            [EnumMember(Value = "BJB")]
            Bjb,

            [EnumMember(Value = "CIMB")]
            Cimb,

            [EnumMember(Value = "MANDIRI")]
            Mandiri,

            [EnumMember(Value = "PERMATA")]
            Permata,

            [EnumMember(Value = "SAHABAT_SAMPOERNA")]
            SahabatSampoerna,

            [EnumMember(Value = "BSI")]
            Bsi,

        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Status
        {
            Unknown,

            [EnumMember(Value = "PENDING")]
            Pending,

            [EnumMember(Value = "ACTIVE")]
            Active,

            [EnumMember(Value = "INACTIVE")]
            Inactive,
        }
    }
}
