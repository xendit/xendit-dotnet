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
            DcBRI,

            [EnumMember(Value = "BCA_ONEKLIK")]
            BCAOneKlik,

            [EnumMember(Value = "BA_BPI")]
            BaBPI,

            [EnumMember(Value = "BA_UBP")]
            BaUBP,
        }
    }
}