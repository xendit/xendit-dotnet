namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;

    public enum CustomerAddressCategory
    {
        [EnumMember(Value = "HOME")]
        Home,

        [EnumMember(Value = "WORK")]
        Work,

        [EnumMember(Value = "PROVINCIAL")]
        Provincial,
    }
}
