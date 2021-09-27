namespace XenditTest.LinkedAccountTest
{
    using System.Collections.Generic;
    using Xendit.net.Enum;
    using Xendit.net.Model.LinkedAccountToken;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly string LinkedAccountUrl = "/linked_account_tokens";
        internal static readonly string LinkedAccountAuthUrl = string.Format("{0}{1}", LinkedAccountUrl, "/auth");

        internal static readonly InitializedLinkedAccountTokenParameter InitializedLinkedAccountParameter = new InitializedLinkedAccountTokenParameter
        {
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
            Properties = new LinkedAccountTokenProperties
            {
                AccountMobileNumber = "+62818555988",
                CardLastFour = "4444",
                CardExpiry = "06/24",
                AccountEmail = "test@email.com",
            },
            Metadata = new Dictionary<string, object>()
            {
                { "example-metadata", "here is the example" },
            },
        };

        internal static readonly InitializedLinkedAccountToken ExpectedInitializedLinkedAccount = new InitializedLinkedAccountToken
        {
            Id = LinkedAccountId,
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
            AuthorizerUrl = "https://url.com/",
            Status = LinkedAccountEnum.Status.Pending,
            Metadata = new Dictionary<string, object>()
            {
                { "example-metadata", "here is the example" },
            },
        };

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly string OtpCode = "012345";
        internal static readonly Dictionary<string, string> ValidatedLinkedAccountParameter = new Dictionary<string, string>
        {
            { "otp_code", OtpCode },
        };

        internal static readonly string LinkedAccountId = "lat-aa620619-124f-41db-995b-66a52abe036a";
        internal static readonly string LinkedAccountValidateUrl = string.Format("{0}/{1}/{2}", LinkedAccountUrl, LinkedAccountId, "validate_otp");
        internal static readonly string LinkedAccountIdUrl = string.Format("{0}/{1}", LinkedAccountUrl, LinkedAccountId);
        internal static readonly string LinkedAccountAccessibleUrl = string.Format("{0}/{1}/{2}", LinkedAccountUrl, LinkedAccountId, "accounts");

        internal static readonly ValidatedLinkedAccountToken ExpectedValidatedLinkedAccount = new ValidatedLinkedAccountToken
        {
            Id = LinkedAccountId,
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
            Status = LinkedAccountEnum.Status.Success,
        };

        internal static readonly AccessibleLinkedAccountToken[] ExpectedAccessibleLinkedAccounts = new AccessibleLinkedAccountToken[]
        {
            new AccessibleLinkedAccountToken
            {
                Id = LinkedAccountId,
                ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
                Type = LinkedAccountEnum.Type.DebitCard,
                Properties = new LinkedAccountTokenProperties
                {
                    AccountMobileNumber = "+62818555988",
                    CardLastFour = "4444",
                    CardExpiry = "06/24",
                    AccountEmail = "test@email.com",
                },
            },
        };

        internal static readonly UnbindedLinkedAccountToken ExpectedUnbindedLinkedAccount = new UnbindedLinkedAccountToken
        {
            Id = LinkedAccountId,
            IsDeleted = true,
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
