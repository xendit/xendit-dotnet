namespace XenditTest.LinkedAccountTest
{
    using System.Collections.Generic;
    using Xendit.net.Enum;
    using Xendit.net.Model;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly string LinkedAccountUrl = "https://api.xendit.co/linked_account_tokens";
        internal static readonly string LinkedAccountAuthUrl = string.Format("{0}{1}", LinkedAccountUrl, "/auth");

        internal static readonly InitializedLinkedAccountParameter InitializedLinkedAccountParameter = new InitializedLinkedAccountParameter
        {
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBRI,
            Properties = new LinkedAccountProperties
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

        internal static readonly InitializedLinkedAccount ExpectedInitializedLinkedAccount = new InitializedLinkedAccount
        {
            Id = LinkedAccountId,
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBRI,
            AuthorizerUrl = "https://url.com/",
            Status = LinkedAccountEnum.Status.Pending,
            Metadata = new Dictionary<string, object>()
            {
                { "example-metadata", "here is the example" },
            },
        };

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly ValidatedLinkedAccountParameter ValidatedLinkedAccountParameter = new ValidatedLinkedAccountParameter
        {
            OTPCode = "012345",
        };

        internal static readonly string LinkedAccountId = "lat-aa620619-124f-41db-995b-66a52abe036a";
        internal static readonly string LinkedAccountValidateUrl = string.Format("{0}/{1}/{2}", LinkedAccountUrl, LinkedAccountId, "validate_otp");
        internal static readonly string LinkedAccountIdUrl = string.Format("{0}/{1}", LinkedAccountUrl, LinkedAccountId);
        internal static readonly string LinkedAccountAccessibleUrl = string.Format("{0}/{1}/{2}", LinkedAccountUrl, LinkedAccountId, "accounts");

        internal static readonly ValidatedLinkedAccount ExpectedValidatedLinkedAccount = new ValidatedLinkedAccount
        {
            Id = LinkedAccountId,
            CustomerId = "customer-id",
            ChannelCode = LinkedAccountEnum.ChannelCode.DcBRI,
            Status = LinkedAccountEnum.Status.Success,
        };

        internal static readonly AccessibleLinkedAccount[] ExpectedAccessibleLinkedAccounts = new AccessibleLinkedAccount[]
        {
            new AccessibleLinkedAccount
            {
                Id = LinkedAccountId,
                ChannelCode = LinkedAccountEnum.ChannelCode.DcBRI,
                Type = LinkedAccountEnum.Type.DebitCard,
                Properties = new LinkedAccountProperties
                {
                    AccountMobileNumber = "+62818555988",
                    CardLastFour = "4444",
                    CardExpiry = "06/24",
                    AccountEmail = "test@email.com",
                },
            },
        };

        internal static readonly UnbindedLinkedAccount ExpectedUnbindedLinkedAccount = new UnbindedLinkedAccount
        {
            Id = LinkedAccountId,
            IsDeleted = true,
        };
    }
}
