namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class CustomerIndividualDetail
    {
        [JsonPropertyName("given_names")]
        public string GivenNames { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("gender")]
        public CustomerGender Gender { get; set; }

        [JsonPropertyName("employment")]
        public CustomerEmployment Employment { get; set; }
    }
}
