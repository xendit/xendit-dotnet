namespace Xendit.net.Struct
{
    using System.Collections.Generic;
    using Xendit.net.Enum;

    public struct PaymentMethodParameter
    {
        public PaymentMethodAccountType Type { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public string CustomerId { get; set; }

        public Dictionary<string, object> Metadata { get; set; }
    }
}
