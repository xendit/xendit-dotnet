namespace XenditTest.PaymentMethodTest
{
    using Xendit.net.Enum;
    using Xendit.net.Model.PaymentMethod;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly PaymentMethodResponse ExpectedPaymentMethod = new PaymentMethodResponse
        {
            Id = "payment-method-id",
            Type = PaymentMethodEnum.AccountType.DebitCard,
            Properties = PaymentMethodBodyProperties,
            CustomerId = "customer-id",
            Status = PaymentMethodEnum.Status.Active,
            Created = "2020-03-19T05:34:55+0800",
            Updated = "2020 - 03 - 19T05:24:55 + 0800",
            Metadata = null,
        };

        internal static readonly PaymentMethodResponse[] ExpectedPaymentMethods = new PaymentMethodResponse[] { ExpectedPaymentMethod };

        internal static readonly PaymentMethodProperties PaymentMethodBodyProperties = new PaymentMethodProperties
        {
            ChannelCode = PaymentMethodEnum.ChannelCode.DcBri,
            Currency = Currency.IDR,
            CardLastFour = "1234",
            CardExpiry = "06/24",
            Description = "This is example of payment method",
        };

        internal static readonly PaymentMethodParameter PaymentMethodBody = new PaymentMethodParameter
        {
            Type = PaymentMethodEnum.AccountType.DebitCard,
            Properties = PaymentMethodBodyProperties,
            CustomerId = "customer-id",
            Metadata = null,
        };

        internal static readonly string CustomerId = "customer-id";

        internal static readonly string PaymentMethodUrl = "/payment_methods";
        internal static readonly string GetPaymentMethodByCustomerIdUrl = string.Format("{0}{1}{2}", PaymentMethodUrl, "?customer_id=", CustomerId);

        internal static readonly HeaderParameter CustomHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
