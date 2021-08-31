namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class PaymentMethodEnum
    {
        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Status
        {
            Unknown,

            [EnumMember(Value = "ACTIVE")]
            Active,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum AccountType
        {
            Unknown,

            [EnumMember(Value = "DEBIT_CARD")]
            DebitCard,

            [EnumMember(Value = "BANK_REDIRECT")]
            BankRedirect,

            [EnumMember(Value = "BANK_ACCOUNT")]
            BankAccount,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum ChannelCode
        {
            Unknown,

            [EnumMember(Value = "DC_BRI")]
            DcBRI,

            [EnumMember(Value = "BCA_ONEKLIK")]
            BCAOneKlik,

            [EnumMember(Value = "BCA_KLIKPAY")]
            BCAKlikPay,

            [EnumMember(Value = "BA_BPI")]
            BaBPI,

            [EnumMember(Value = "BA_UBP")]
            BaUBP,
        }
    }
}
