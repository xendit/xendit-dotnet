﻿namespace Xendit.net.Model.Customer
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class KycDocument
    {
        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("type")]
        public CustomerKycDocumentType Type { get; set; }

        [JsonPropertyName("sub_type")]
        public CustomerKycDocumentSubType? SubType { get; set; }

        [JsonPropertyName("document_name")]
        public string DocumentName { get; set; }

        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonPropertyName("holder_name")]
        public string HolderName { get; set; }

        [JsonPropertyName("document_images")]
        public string[] DocumentImages { get; set; }
    }
}
