namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;

    public enum CustomerIdentityAccountType
    {
        [EnumMember(Value = "BANK_ACCOUNT")]
        BankAccount,

        [EnumMember(Value = "EWALLET")]
        Ewallet,

        [EnumMember(Value = "CREDIT_CARD")]
        CreditCard,

        [EnumMember(Value = "PAY_LATER")]
        PayLater,

        [EnumMember(Value = "OTC")]
        Otc,

        [EnumMember(Value = "QR_CODE")]
        QrCode,

        [EnumMember(Value = "SOCIAL_MEDIA")]
        SocialMedia,
    }
}
