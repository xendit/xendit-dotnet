namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public struct ValidatedLinkedAccountParameter
    {
        [JsonPropertyName("otp_code")]
        public string OTPCode { get; set; }
    }
}
