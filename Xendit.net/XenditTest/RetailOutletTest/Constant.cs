namespace XenditTest.RetailOutletTest
{
    using Xendit.net.Enum;
    using Xendit.net.Model.RetailOutlet;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly string RetailOutletUrl = "/payment_codes";
        internal static readonly CreateFixedPaymentCodeParameter CreateFixedPaymentCodeParameter = new CreateFixedPaymentCodeParameter
        {
            ReferenceId = "reference_id",
            ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
            Amount = 1000,
            Currency = Currency.PHP,
            CustomerName = "Rika Sutanto",
            Market = Country.Philippines,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            IsSingleUse = false,
            Description = "Example of payment code",
            Metadata = null,
        };

        internal static readonly CreateFixedPaymentCodeParameter InvalidCreateFixedPaymentCodeParameter = new CreateFixedPaymentCodeParameter
        {
            ReferenceId = "reference_id",
            ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
            Amount = 1000,
            Currency = Currency.IDR,
            CustomerName = "Rika Sutanto",
            Market = Country.Indonesia,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            IsSingleUse = false,
            Description = "Example of payment code",
            Metadata = null,
        };

        internal static readonly FixedPaymentCode ExpectedFixedPaymentCode = new FixedPaymentCode
        {
            Id = "pcode-559bb2df-6ae7-4fb8-bc05-f17aa07aeae1",
            BusinessId = "5f21361959ef2b788cbbe97f",
            ReferenceId = "reference_id",
            CustomerName = "Rika Sutanto",
            PaymentCode = "TEST906558",
            Currency = Currency.PHP,
            Amount = 1000,
            IsSingleUse = false,
            ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
            Description = "Example of payment code",
            Market = Country.Philippines,
            Status = RetailOutletEnum.Status.Active,
            Metadata = null,
            CreatedAt = "2021-05-30T02:38:01.327283048Z",
            UpdatedAt = "2021-05-30T02:38:01.327283048Z",
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
        };

        internal static readonly FixedPaymentCode[] ExpectedFixedPaymentCodes = new FixedPaymentCode[]
        {
            ExpectedFixedPaymentCode,
        };

        internal static readonly PaymentsResponse ExpectedPaymentsResponse = new PaymentsResponse() {
            Data = new Payment[] { new Payment{
                Status = "COMPLETED",
                FixedPaymentCodePaymentId = "61c53c4fdc1b825d9a58ff54",
                FixedPaymentCodeId = "61c53c3727c7a679826dd90a",
                Amount = 1000,
                Name = "JOHN DOE",
                Prefix = "TEST",
                PaymentCode = "TEST892185",
                PaymentId = "1640315983260",
                ExternalId = "FPC-1640315959",
                RetailOutletName = "ALFAMART",
                TransactionTimestamp = "2021-12-24T03:19:43.260Z",
                Id = "61c53c4f6cc577e4038ab099",
                OwnerId = "60ca10b83ffd534ece8aa856",
            }},
            HasMore = true,
            Links = new Links() {
                Href = "https://api.xendit.co/fixed_payment_code/61c53c3727c7a679826dd90a/payments?limit=1&after_id=61c53c4f6cc577e4038ab099",
                Rel = "next",
                Method = "GET",
            }
        };

        internal static readonly UpdateFixedPaymentCodeParameter UpdateFixedPaymentCodeParameter = new UpdateFixedPaymentCodeParameter
        {
            CustomerName = "Rika Sutanto",
            Amount = 1000,
            Currency = Currency.PHP,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            Description = "Example of payment code",
        };

        internal static readonly UpdateFixedPaymentCodeParameter InvalidUpdateFixedPaymentCodeParameter = new UpdateFixedPaymentCodeParameter
        {
            CustomerName = "Rika Sutanto",
            Amount = 1000,
            Currency = Currency.IDR,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            Description = "Example of payment code",
        };

        internal static readonly string PaymentCodeId = "payment_code_id";
        internal static readonly string FixedPaymentCodeId = "fixed_payment_code_id";
        internal static readonly string PaymentCodeIdUrl = string.Format("{0}/{1}", RetailOutletUrl, PaymentCodeId);
        internal static readonly string GetPaymentsUrl = string.Format("{0}/payments", PaymentCodeIdUrl);
        internal static readonly string GetPaymentsByFixedPaymentCodeUrl = string.Format("/fixed_payment_code/{0}/payments", FixedPaymentCodeId);
        internal static readonly HeaderParameter Headers = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
