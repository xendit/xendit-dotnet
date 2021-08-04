namespace XenditTest.InvoiceTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    using Xendit.net.Model;

    internal static class Constant
    {
        internal static readonly Invoice ExpectedInvoice = new Invoice
        {
            Id = "invoice_id",
            ExternalId = "external_id",
            UserId = "user_id",
            Amount = new BigInteger(1000),
            Status = "PENDING",
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
            Currency = "IDR",
            SuccessRedirectUrl = "redirect_url",
            FailureRedirectUrl = "redirect_url",
            PaidAt = "2020-01-31T11:20:01.017Z",
            CreditCardChargeId = "credit_id",
            PaymentMethod = "transfer",
            PaymentChannel = "BCA",
            PaymentDestination = "012",
            FixedVa = true,
        };

        internal static readonly Dictionary<string, object> QueryParams = new Dictionary<string, object>()
        {
            { "limit", 1 },
            { "created_after", "2016-02-24T23:48:36.697Z" },
        };

        internal static readonly Invoice[] ExpectedInvoiceArray = new Invoice[] { ExpectedInvoice };

        internal static readonly string InvoiceId = "invoice_id";
        internal static readonly string InvoiceV2Url = "https://api.xendit.co/v2/invoices";
        internal static readonly string InvoiceByIdUrl = string.Format("{0}/{1}", InvoiceV2Url, InvoiceId);
        internal static readonly string InvoiceListUrl = string.Format("{0}?{1}", InvoiceV2Url, "&limit=1&created_after=2016-02-24T23:48:36.697Z");

        internal static readonly string InvoiceExpireUrl = string.Format("https://api.xendit.co/invoices/{0}/expire!", InvoiceId);

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly Dictionary<string, object> InvoiceBody = new Dictionary<string, object>()
        {
            { "external_id", "external_id" },
            { "amount", new BigInteger(1000) },
        };
    }
}
