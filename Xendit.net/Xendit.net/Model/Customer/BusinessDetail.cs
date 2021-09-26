namespace Xendit.net.Model.Customer
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class BusinessDetail
    {
        [JsonPropertyName("business_name")]
        public string BusinessName { get; set; }

        [JsonPropertyName("business_type")]
        public CustomerBusinessType? BusinessType { get; set; }

        [JsonPropertyName("nature_of_business")]
        public string NatureOfBusiness { get; set; }

        [JsonPropertyName("business_domicile")]
        public string BusinessDomicile { get; set; }

        [JsonPropertyName("date_of_registration")]
        public string DateOfRegistration { get; set; }
    }
}
