namespace Xendit.net.Model
{
    using System.Text.Json.Serialization;

    public class LinkedAccountProperties
    {
        [JsonPropertyName("account_mobile_number")]
        public string AccountMobileNumber { get; set; }

        [JsonPropertyName("card_last_four")]
        public string CardLastFour { get; set; }

        [JsonPropertyName("card_expiry")]
        public string CardExpiry { get; set; }

        [JsonPropertyName("account_email")]
        public string AccountEmail { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("device")]
        public LinkedAccountDevice Device { get; set; }
    }
}
