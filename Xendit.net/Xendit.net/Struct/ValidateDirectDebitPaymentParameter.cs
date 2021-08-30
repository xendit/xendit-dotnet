namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;

    public class ValidateDirectDebitPaymentParameter
    {
        [JsonPropertyName("otp_code")]
        public string OTPCode { get; set; }
    }
}
