﻿namespace Xendit.net.Enum
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CustomerAddressCategory
    {
        Unknown,

        [EnumMember(Value = "HOME")]
        Home,

        [EnumMember(Value = "WORK")]
        Work,

        [EnumMember(Value = "PROVINCIAL")]
        Provincial,
    }
}
