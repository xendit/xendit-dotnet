namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;
    using Xendit.net.Model.Customer;

    public struct CustomerParameter
    {
        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("mobile_number")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("given_names")]
        public string GivenNames { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonPropertyName("type")]
        public CustomerType? Type { get; set; }

        [JsonPropertyName("individual_detail")]
        public IndividualDetail IndividualDetail { get; set; }

        [JsonPropertyName("business_detail")]
        public BusinessDetail BusinessDetail { get; set; }

        [JsonPropertyName("identity_accounts")]
        public IdentityAccount[] IdentityAccount { get; set; }

        [JsonPropertyName("kyc_documents")]
        public KycDocument[] KycDocuments { get; set; }
    }
}
