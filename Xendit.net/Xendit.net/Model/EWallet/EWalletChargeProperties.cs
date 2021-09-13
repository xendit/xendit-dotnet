namespace Xendit.net.Model.EWallet
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public class EWalletChargeProperties
    {
        [JsonPropertyName("mobile_number")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("success_redirect_url")]
        public string SuccessRedirectUrl { get; set; }

        [JsonPropertyName("failure_redirect_url")]
        public string FailureRedirectUrl { get; set; }

        [JsonPropertyName("cancel_redirect_url")]
        public string CancelRedirectUrl { get; set; }

        [JsonPropertyName("redeem_points")]
        public EWalletEnum.RedeemPoints? RedeemPoints { get; set; }
    }
}
