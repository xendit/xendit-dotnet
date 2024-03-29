﻿namespace Xendit.net.Model.Customer
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class Address
    {
        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("street_line1")]
        public string StreetLine1 { get; set; }

        [JsonPropertyName("street_line2")]
        public string StreetLine2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("province_state")]
        public string ProvinceState { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("category")]
        public CustomerAddressCategory? Category { get; set; }

        [JsonPropertyName("is_primary")]
        public bool? IsPrimary { get; set; }
    }
}
