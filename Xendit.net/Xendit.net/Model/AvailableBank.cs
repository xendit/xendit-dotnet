using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Xendit.net.Model
{
    public class AvailableBank
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
