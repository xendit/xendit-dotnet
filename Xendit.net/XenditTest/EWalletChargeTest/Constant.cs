namespace XenditTest.EWalletChargeTest
{
    using System.Collections.Generic;
    using Xendit.net.Model;

    internal class Constant
    {
        internal static readonly EWalletCharge ExpectedEWalletCharge = new EWalletCharge
        {
            Id = "charge-id",
            BusinessId = "5f218745736e619164dc8608",
            ReferenceId = "test-reference-id",
            Status = "PENDING",
            Currency = "IDR",
            ChargeAmount = 1000,
            CaptureAmount = 1000,
            CheckoutMethod = "ONE_TIME_PAYMENT",
            ChannelCode = "ID_SHOPEEPAY",
            ChannelProperties = new Dictionary<string, string>()
            {
                { "success_redirect_url",  "https://dashboard.xendit.co/register/1" },
            },
            Actions = new Dictionary<string, string>()
            {
                { "desktop_web_checkout_url",  "https://dashboard.xendit.co/register/1" },
                { "mobile_web_checkout_url", null },
                { "mobile_deeplink_checkout_url",  "https://deeplinkcheckout.this/" },
                { "qr_checkout_string", "ID123XenditQRTest321DI" },
            },
            IsRedirectRequired = true,
            CallbackUrl = "https://calling-back.com/xendit/shopeepay",
            Created = "2017-07-21T17:32:28Z",
            Updated = "2017-07-21T17:32:28Z",
            VoidedAt = null,
            CaptureNow = true,
            CustomerId = null,
            PaymentMethodId = null,
            FailureCode = null,
            Basket = null,
            Metadata = new Dictionary<string, object>()
            {
                { "branch_code", "tree_branch" },
            },
        };

        internal static readonly string ReferenceId = "test-reference-id";
        internal static readonly string Currency = "IDR";
        internal static readonly long Amount = 1000;
        internal static readonly string CheckoutMethod = "ONE_TIME_PAYMENT";
        internal static readonly string ChannelCode = "ID_SHOPEEPAY";
        internal static readonly Dictionary<string, string> ChannelProperties = new Dictionary<string, string>()
        {
            { "success_redirect_url",  "https://dashboard.xendit.co/register/1" },
        };

        internal static readonly Dictionary<string, object> EWalletBody = new Dictionary<string, object>()
        {
            { "reference_id", ReferenceId },
            { "currency", Currency },
            { "amount", Amount },
            { "checkout_method", CheckoutMethod },
            { "channel_code", ChannelCode },
            { "channel_properties", ChannelProperties },
            { "payment_method_id", null },
            { "customer_id", null },
            { "basket", null },
            { "metadata", null },
        };

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly string ChargeId = "charge-id";
        internal static readonly string EWalletChargeUrl = "https://api.xendit.co/ewallets/charges";
        internal static readonly string GetChargeUrl = string.Format("{0}/{1}", EWalletChargeUrl, ChargeId);
    }
}
