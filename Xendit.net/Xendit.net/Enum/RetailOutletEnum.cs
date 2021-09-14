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
            Ecpay,
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

            [EnumMember(Value = "EXPIRED")]
            Expired,

            [EnumMember(Value = "COMPLETED")]
            Completed,
        }
    }
}
