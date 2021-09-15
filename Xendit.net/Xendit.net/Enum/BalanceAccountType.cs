namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum BalanceAccountType
    {
        [EnumMember(Value = "CASH")]
        Cash,

        [EnumMember(Value = "HOLDING")]
        Holding,

        [EnumMember(Value = "TAX")]
        Tax,
    }
}
