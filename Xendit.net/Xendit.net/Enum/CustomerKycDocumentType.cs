namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;

    public enum CustomerKycDocumentType
    {
        [EnumMember(Value = "BIRTH_CERTIFICATE")]
        BirthCertificate,

        [EnumMember(Value = "BANK_STATEMENT")]
        BankStatement,

        [EnumMember(Value = "DRIVING_LICENSE")]
        DrivingLicense,

        [EnumMember(Value = "IDENTITY_CARD")]
        IdentityCard,

        [EnumMember(Value = "PASSPORT")]
        Passport,

        [EnumMember(Value = "VISA")]
        Visa,

        [EnumMember(Value = "BUSINESS_REGISTRATION")]
        BusinessRegistration,

        [EnumMember(Value = "BUSINESS_LICENSE")]
        BusinessLicense,
    }
}
