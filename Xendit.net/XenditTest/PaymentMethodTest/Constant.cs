namespace XenditTest.PaymentMethodTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xendit.net.Model;

    internal class Constant
    {
        internal static readonly PaymentMethod ExpectedPaymentMethod = new PaymentMethod
        {
            Id = "payment-method-id",
            Type = "DEBIT_CARD",
            Properties = PaymentMethodBodyProperties,
            CustomerId = "customer-id",
            Status = "ACTIVE",
            Created = "2020-03-19T05:34:55+0800",
            Updated = "2020 - 03 - 19T05:24:55 + 0800",
            Metadata = null,
        };

        internal static readonly PaymentMethod[] ExpectedPaymentMethods = new PaymentMethod[] { ExpectedPaymentMethod };

        internal static readonly Dictionary<string, object> PaymentMethodBodyProperties = new Dictionary<string, object>()
        {
            { "id", "la-aa620619-124f-41db-995b-66a52abe036a" },
            { "channel_code", "DC_BRI" },
            { "currency", "IDR" },
            { "card_last_four", "1234" },
            { "card_expiry", "06/24" },
            { "description", null },
        };

        internal static readonly Dictionary<string, object> PaymentMethodBody = new Dictionary<string, object>()
        {
            { "customer_id", "customer-id" },
            { "type", "DEBIT_CARD" },
            { "properties", PaymentMethodBodyProperties },
        };

        internal static readonly string CustomerId = "customer-id";

        internal static readonly string PaymentMethodUrl = "https://api.xendit.co/payment_methods";
        internal static readonly string GetPaymentMethodByCustomerIdUrl = string.Format("{0}{1}{2}", PaymentMethodUrl, "?customer_id=", CustomerId);

        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };
    }
}
