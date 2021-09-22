namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class EWalletEnum
    {
        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum CheckoutMethod
        {
            Unknown,

            [EnumMember(Value = "ONE_TIME_PAYMENT")]
            OneTimePayment,

            [EnumMember(Value = "TOKENIZED_PAYMENT")]
            TokenizedPayment,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum RedeemPoints
        {
            Unknown,

            [EnumMember(Value = "REDEEM_NONE")]
            RedeemNone,

            [EnumMember(Value = "REDEEM_ALL")]
            RedeemAll,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum ChannelCode
        {
            Unknown,

            [EnumMember(Value = "ID_OVO")]
            IdOvo,

            [EnumMember(Value = "ID_DANA")]
            IdDana,

            [EnumMember(Value = "ID_LINKAJA")]
            IdLinkaja,

            [EnumMember(Value = "ID_SHOPEEPAY")]
            IdShopeepay,

            [EnumMember(Value = "ID_SAKUKU")]
            IdSakuku,

            [EnumMember(Value = "PH_PAYMAYA")]
            PhPaymaya,

            [EnumMember(Value = "PH_GCASH")]
            PhGcash,

            [EnumMember(Value = "PH_GRABPAY")]
            PhGrabpay,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Status
        {
            Unknown,

            [EnumMember(Value = "SUCCEDED")]
            Succeded,

            [EnumMember(Value = "PENDING")]
            Pending,

            [EnumMember(Value = "FAILED")]
            Failed,

            [EnumMember(Value = "VOIDED")]
            Voided,

            [EnumMember(Value = "COMPLETED")]
            Completed,

            [EnumMember(Value = "PAID")]
            Paid,

            [EnumMember(Value = "EXPIRED")]
            Expired,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum ProductType
        {
            Unknown,

            [EnumMember(Value = "PRODUCT")]
            Product,

            [EnumMember(Value = "SERVICE")]
            Service,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum PaymentType
        {
            Unknown,

            [EnumMember(Value = "OVO")]
            Ovo,

            [EnumMember(Value = "DANA")]
            Dana,

            [EnumMember(Value = "LINKAJA")]
            Linkaja,
        }
    }
}
