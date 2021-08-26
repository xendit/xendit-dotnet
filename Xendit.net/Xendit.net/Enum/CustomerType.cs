namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;

    public enum CustomerType
    {
        [EnumMember(Value = "INDIVIDUAL")]
        Individual,

        [EnumMember(Value = "BUSINESS")]
        Business,
    }
}
