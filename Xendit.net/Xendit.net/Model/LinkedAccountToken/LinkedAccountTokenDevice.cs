﻿namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Text.Json.Serialization;

    public class LinkedAccountTokenDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }

        [JsonPropertyName("ad_id")]
        public string AdId { get; set; }

        [JsonPropertyName("imei")]
        public string Imei { get; set; }
    }
}
