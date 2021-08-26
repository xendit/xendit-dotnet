namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    public enum CustomerKycDocumentSubType
    {
        Unknown,

        [EnumMember(Value = "NATIONAL_ID")]
        NationalId,

        [EnumMember(Value = "CONSULAR_ID")]
        ConsularId,

        [EnumMember(Value = "VOTER_ID")]
        VoterId,

        [EnumMember(Value = "POSTAL_ID")]
        PostalId,

        [EnumMember(Value = "RESIDENCE_PERMIT")]
        ResidencePermit,

        [EnumMember(Value = "TAX_ID")]
        TaxId,

        [EnumMember(Value = "STUDENT_ID")]
        StudentId,

        [EnumMember(Value = "MILITARY_ID")]
        MilitaryId,

        [EnumMember(Value = "MEDICAL_ID")]
        MedicalId,
    }
}
