namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;

    public enum CustomerGender
    {
        [EnumMember(Value = "MALE")]
        Male,

        [EnumMember(Value = "FEMALE")]
        Female,

        [EnumMember(Value = "OTHER")]
        Other,
    }
}
