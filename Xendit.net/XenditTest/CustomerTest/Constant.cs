namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using Xendit.net.Model;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly Dictionary<string, string> CustomHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
            { "API-VERSION", "2020-10-31" },
        };

        internal static readonly Dictionary<string, string> UserIdHeaders = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
        };

        internal static readonly Dictionary<string, string> ApiVersionHeaders = new Dictionary<string, string>()
        {
            { "API-VERSION", "2020-05-19" },
        };

        internal static readonly Dictionary<string, string> NewApiVersionHeaders = new Dictionary<string, string>()
        {
            { "API-VERSION", "2020-10-31" },
        };

        internal static readonly Dictionary<string, string> NewApiVersionHeadersWithUserId = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
            { "API-VERSION", "2020-10-31" },
        };

        internal static readonly string CustomerUrl = "https://api.xendit.co/customers";

        internal static readonly Customer ExpectedCustomerData = new Customer
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

        internal static readonly Customer ExpectedCustomerOldApiVersion = new Customer
        {
            Data = new Customer[] { ExpectedCustomerData },
        };

        internal static readonly CustomerBody CustomerBody = new CustomerBody
        {
            ReferenceId = "demo_1475801962607",
            GivenNames = "John",
            MobileNumber = "+6287774441111",
            Email = "customer@website.com",
        };

        internal static readonly Customer[] ExpectedCustomers = new Customer[] { ExpectedCustomerData };
        internal static readonly string CustomerIdUrl = string.Format("{0}?reference_id={1}", CustomerUrl, ExpectedCustomerData.ReferenceId);

        internal static readonly Customer ExpectedCustomerNewApiVersion = new Customer
        {
            HasMore = false,
            Data = new Customer[] { ExpectedCustomerData },
        };
    }
}
