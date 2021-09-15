namespace Xendit.net.Model.EWallet
{
    using System.Text.Json.Serialization;

    public class Actions
    {
        [JsonPropertyName("desktop_web_checkout_url")]
        public string DesktopWebCheckoutUrl { get; set; }

        [JsonPropertyName("mobile_web_checkout_url")]
        public string MobileWebCheckoutUrl { get; set; }

        [JsonPropertyName("mobile_deeplink_checkout_url")]
        public string MobileDeeplinkCheckoutUrl { get; set; }

        [JsonPropertyName("qr_checkout_string")]
        public string QrCheckoutString { get; set; }
    }
}
