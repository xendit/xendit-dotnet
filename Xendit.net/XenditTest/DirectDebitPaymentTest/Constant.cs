namespace XenditTest.DirectDebitPaymentTest
{
    using System.Collections.Generic;
    using Xendit.net.Enum;
    using Xendit.net.Model.DirectDebit;
    using Xendit.net.Model.LinkedAccountToken;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly DirectDebitPaymentResponse ExpectedDirectDebitPayment = new DirectDebitPaymentResponse
        {
            Id = "generated-id",
            ReferenceId = "reference-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
            PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
            Currency = Currency.IDR,
            Amount = 10000,
            Description = "Example Description",
            Status = DirectDebitStatus.Pending,
            FailureCode = null,
            IsOtpRequired = true,
            OtpMobileNumber = "+6287774441111",
            OtpExpirationTimestamp = "2020-03-26T05:44:26+0800",
            RequiredAction = DirectDebitRequiredAction.ValidateOtp,
            CheckoutUrl = "https://checkout-url.com/",
            SuccessRedirectUrl = "https://success-url.com/",
            FailureRedirectUrl = "https://failure-url.com/",
            RefundedAmount = 1000,
            Refunds = new DirectDebitRefunds
            {
                Data = new string[] { "id-1", "id-2", "id-3" },
                HasMore = false,
                Url = "https://refund-url.com/",
            },
            Created = "2020-03-26T05:44:26+0800",
            Updated = null,
            Metadata = null,
            Basket = new BasketItem[]
            {
                new BasketItem { Name = "shoes", Type = "goods", Price = 2000, Quantity = 1 },
                new BasketItem { Name = "shirt", Type = "goods", Price = 2000, Quantity = 1 },
            },
        };

        internal static readonly DirectDebitPaymentParameter DirectDebitPaymentParameter = new DirectDebitPaymentParameter
        {
            ReferenceId = "reference-id",
            PaymentMethodId = "pm-c30d4800-afe4-4e58-ad5f-cc006d169139",
            Currency = Currency.IDR,
            Amount = 10000,
            CallbackUrl = "https://callback-url.com/",
            EnableOtp = true,
            Description = "Example Description",
            SuccessRedirectUrl = "https://success-url.com/",
            FailureRedirectUrl = "https://failure-url.com/",
            Device = new LinkedAccountTokenDevice
            {
                Id = "device-id",
                IpAddress = "255.255.255.255",
                UserAgent = "App",
                Imei = "imei-example",
                AdId = "ad-id",
            },
            Metadata = null,
            Basket = new BasketItem[]
            {
                new BasketItem { Name = "shoes", Type = "goods", Price = 2000, Quantity = 1 },
                new BasketItem { Name = "shirt", Type = "goods", Price = 2000, Quantity = 1 },
            },
        };

        internal static readonly DirectDebitPaymentResponse[] ExpectedDirectDebitPayments = new DirectDebitPaymentResponse[]
        {
            ExpectedDirectDebitPayment,
        };

        internal static readonly string OtpCode = "otp-code";
        internal static readonly Dictionary<string, string> ValidateDirectDebitPaymentParameter = new Dictionary<string, string>
        {
            { "otp_code",  "otp-code" },
        };

        internal static readonly string DirectDebitId = "generated-id";
        internal static readonly string ReferenceId = "reference-id";
        internal static readonly string DirectDebitUrl = "/direct_debits";
        internal static readonly string DirectDebitUrlValidateOTP = string.Format("{0}/{1}/{2}", DirectDebitUrl, DirectDebitId, "validate_otp/");
        internal static readonly string DirectDebitUrlGetById = string.Format("{0}/{1}/", DirectDebitUrl, DirectDebitId);
        internal static readonly string DirectDebitUrlGetByReferenceId = string.Format("{0}?reference_id={1}", DirectDebitUrl, ReferenceId);

        internal static readonly string IdempotencyKey = "idempotency-key-example";
        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";

        internal static HeaderParameter Headers = new HeaderParameter
        {
            Idempotencykey = IdempotencyKey,
        };

        internal static HeaderParameter InitialHeadersWithUserId = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static HeaderParameter HeadersWithUserId = new HeaderParameter
        {
            ForUserId = "user-id",
            Idempotencykey = IdempotencyKey,
        };
    }
}
