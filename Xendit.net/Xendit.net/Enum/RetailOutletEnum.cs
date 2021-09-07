namespace Xendit.net.Enum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class RetailOutletEnum
    {
        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum ChannelCode
        {
            Unknown,

            [EnumMember(Value = "7ELEVEN")]
            SevenEleven,

            [EnumMember(Value = "7ELEVEN_CLIQQ")]
            SevenElevenCliqq,

            [EnumMember(Value = "CEBUANA")]
            Cebuana,

            [EnumMember(Value = "ECPAY")]
            ECPay,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Currency
        {
            Unknown,

            [EnumMember(Value = "PHP")]
            PHP,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Country
        {
            Unknown,

            [EnumMember(Value = "PH")]
            Philippines,
        }

        [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Status
        {
            Unknown,

            [EnumMember(Value = "ACTIVE")]
            Active,

            [EnumMember(Value = "INACTIVE")]
            Inactive,

            [EnumMember(Value = "COMPLETED")]
            Completed,
        }
    }
}
