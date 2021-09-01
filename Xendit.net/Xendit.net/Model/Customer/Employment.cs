namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class Employment
    {
        [JsonPropertyName("employer_name")]
        public string EmployerName { get; set; }

        [JsonPropertyName("nature_of_business")]
        public string NatureOfBusiness { get; set; }

        [JsonPropertyName("role_description")]
        public string RoleDescription { get; set; }
    }
}
