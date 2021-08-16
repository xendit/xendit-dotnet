namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using Xendit.net.Model;

    internal class Constant
    {
        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
            { "API-VERSION", "2020-05-19" },
        };

        internal static readonly Dictionary<string, string> UserIdHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly Dictionary<string, string> ApiVersionHeaders = new Dictionary<string, string>()
        {
            { "API-VERSION", "2020-05-19" },
        };

        internal static readonly string CustomerUrl = "https://api.xendit.co/customers";

        internal static readonly Customer ExpectedCustomer = new Customer
        {
            Id = "239c16f4-866d-43e8-9341-7badafbc019f",
            ReferenceId = "demo_1475801962607",
            Email = "customer@website.com",
            MobileNumber = "+6287774441111",
            GivenNames = "John",
            Description = "New Customer",
            MiddleName = null,
            Surname = null,
            PhoneNumber = null,
            Nationality = null,
            Addresses = null,
            DateOfBirth = null,
            Metadata = null,
        };

        internal static readonly Dictionary<string, object> CustomerBody = new Dictionary<string, object>()
        {
            { "reference_id", "demo_1475801962607" },
            { "given_names", "John" },
            { "mobile_number", "+6287774441111" },
            { "email", "customer@website.com" },
        };

        internal static readonly Customer[] ExpectedCustomers = new Customer[] { ExpectedCustomer };
        internal static readonly string CustomerIdUrl = string.Format("{0}?reference_id={1}", CustomerUrl, ExpectedCustomer.ReferenceId);
    }
}
