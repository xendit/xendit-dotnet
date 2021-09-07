namespace XenditTest.RetailOutletTest
{
    using System.Collections.Generic;
    using Xendit.net.Enum;
    using Xendit.net.Struct;
    using RetailOutlet = Xendit.net.Model.RetailOutlet;

    internal class Constant
    {
        internal static readonly string RetailOutletUrl = "https://api.xendit.co/payment_codes";
        internal static readonly CreateRetailOutletParameter CreateRetailOutletParameter = new CreateRetailOutletParameter
        {
            ReferenceId = "reference_id",
            ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
            Amount = 1000,
            Currency = RetailOutletEnum.Currency.PHP,
            CustomerName = "Rika Sutanto",
            Market = RetailOutletEnum.Country.Philippines,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            IsSingleUse = false,
            Description = "Example of payment code",
            Metadata = null,
        };

        internal static readonly RetailOutlet ExpectedRetailOutlet = new RetailOutlet
        {
            Id = "pcode-559bb2df-6ae7-4fb8-bc05-f17aa07aeae1",
            BusinessId = "5f21361959ef2b788cbbe97f",
            ReferenceId = "reference_id",
            CustomerName = "Rika Sutanto",
            PaymentCode = "TEST906558",
            Currency = RetailOutletEnum.Currency.PHP,
            Amount = 1000,
            IsSingleUse = false,
            ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
            Description = "Example of payment code",
            Market = RetailOutletEnum.Country.Philippines,
            Status = RetailOutletEnum.Status.Active,
            Metadata = null,
            CreatedAt = "2021-05-30T02:38:01.327283048Z",
            UpdatedAt = "2021-05-30T02:38:01.327283048Z",
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
        };

        internal static readonly RetailOutlet[] ExpectedRetailOutlets = new RetailOutlet[]
        {
            ExpectedRetailOutlet,
        };

        internal static readonly UpdateRetailOutletParameter UpdateRetailOutletParameter = new UpdateRetailOutletParameter
        {
            CustomerName = "Rika Sutanto",
            Amount = 1000,
            Currency = RetailOutletEnum.Currency.PHP,
            ExpiresAt = "2021-05-30T02:38:01.327283048Z",
            Description = "Example of payment code",
        };

        internal static readonly string PaymentCodeId = "payment_code_id";
        internal static readonly string PaymentCodeIdUrl = string.Format("{0}/{1}", RetailOutletUrl, PaymentCodeId);
        internal static readonly string GetPaymentsUrl = string.Format("{0}/payments", PaymentCodeIdUrl);
        internal static readonly Dictionary<string, string> Headers = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };
    }
}
