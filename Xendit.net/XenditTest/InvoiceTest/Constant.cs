namespace XenditTest.InvoiceTest
{
    using Xendit.net.Common;
    using Xendit.net.Enum;
    using Xendit.net.Model.Invoice;
    using Xendit.net.Struct;

    internal static class Constant
    {
        internal static readonly InvoiceResponse ExpectedInvoice = new InvoiceResponse
        {
            Id = "invoice_id",
            ExternalId = "external_id",
            UserId = "user_id",
            Amount = 1000,
            Status = InvoiceStatus.Pending,
            MerchantName = "XENDIT",
            MerchantProfilePictureUrl = "image_url",
            PayerEmail = "somebody@xendit.co",
            Description = "description",
            InvoiceUrl = "invoice_url",
            ExpiryDate = "2020-01-31T11:20:01.017Z",
            AvailableBanks = { },
            AvailableRetailOutlets = { },
            AvailableEwallets = { },
            ShouldExcludeCreditCard = false,
            ShouldSendEmail = true,
            Updated = "2020-01-31T11:20:01.017Z",
            Created = "2020-01-31T11:20:01.017Z",
            MidLabel = "test_mid",
            Currency = Currency.IDR,
            SuccessRedirectUrl = "redirect_url",
            FailureRedirectUrl = "redirect_url",
            PaidAt = "2020-01-31T11:20:01.017Z",
            CreditCardChargeId = "credit_id",
            PaymentMethod = InvoicePaymentMethodType.BankTransfer,
            PaymentChannel = InvoicePaymentChannelType.Bca,
            PaymentDestination = "012",
            FixedVa = true,
        };

        internal static readonly ListInvoiceParameter QueryParams = new ListInvoiceParameter
        {
            Limit = 1,
            ClientTypes = new InvoiceClientType[] { InvoiceClientType.ApiGateway, InvoiceClientType.Dashboard },
        };

        internal static readonly InvoiceResponse[] ExpectedInvoiceArray = new InvoiceResponse[] { ExpectedInvoice };

        internal static readonly string InvoiceId = "invoice_id";
        internal static readonly string InvoiceV2Url = "/v2/invoices";
        internal static readonly string InvoiceByIdUrl = string.Format("{0}/{1}", InvoiceV2Url, InvoiceId);
        internal static readonly string InvoiceListUrl = string.Format("{0}?{1}", InvoiceV2Url, QueryParamsBuilder.Build(QueryParams));

        internal static readonly string InvoiceExpireUrl = string.Format("/invoices/{0}/expire!", InvoiceId);

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly InvoiceParameter InvoiceBody = new InvoiceParameter
        {
            ExternalId = "external_id",
            Amount = 1000L,
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
