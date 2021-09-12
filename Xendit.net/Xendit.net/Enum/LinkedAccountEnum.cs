namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class LinkedAccountEnum
    {
        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum ChannelCode
        {
            Unknown,

            [EnumMember(Value = "DC_BRI")]
            DcBri,

            [EnumMember(Value = "BCA_ONEKLIK")]
            BcaOneklik,

            [EnumMember(Value = "BA_BPI")]
            BaBpi,

            [EnumMember(Value = "BA_UBP")]
            BaUbp,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Status
        {
            Unknown,

            [EnumMember(Value = "PENDING")]
            Pending,

            [EnumMember(Value = "SUCCESS")]
            Success,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Type
        {
            Unknown,

            [EnumMember(Value = "DEBIT_CARD")]
            DebitCard,

            [EnumMember(Value = "BANK_ACCOUNT")]
            BankAccount,
        }
    }
}
