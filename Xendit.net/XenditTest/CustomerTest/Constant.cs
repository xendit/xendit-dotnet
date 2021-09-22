namespace XenditTest.CustomerTest
{
    using System.Collections.Generic;
    using Xendit.net.Model.Customer;
    using Xendit.net.Struct;

    internal class Constant
    {
        internal static readonly string ApiVersion = "2020-05-19";
        internal static readonly Dictionary<string, string> ApiVersionHeadersWithUserId = new Dictionary<string, string>()
        {
            { "for-user-id", "user-id" },
            { "API-VERSION", "2020-05-19" },
        };

        internal static readonly HeaderParameter NewApiVersionHeadersWithUserId = new HeaderParameter
        {
            ForUserId = "user-id",
            ApiVersion = Xendit.net.Enum.ApiVersion.Version20201031,
        };

        internal static readonly HeaderParameter ApiVersionHeaders = new HeaderParameter
        {
            ApiVersion = Xendit.net.Enum.ApiVersion.Version20200519,
        };

        internal static readonly HeaderParameter NewApiVersionHeaders = new HeaderParameter
        {
            ApiVersion = Xendit.net.Enum.ApiVersion.Version20201031,
        };

        internal static readonly HeaderParameter UserIdHeaders = new HeaderParameter
        {
            ForUserId = "user-id",
        };

        internal static readonly string CustomerUrl = "/customers";

        internal static readonly CustomerResponse ExpectedCustomerData = new CustomerResponse
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

        internal static readonly CustomerResponse ExpectedCustomerOldApiVersion = new CustomerResponse
        {
            Data = new CustomerResponse[] { ExpectedCustomerData },
        };

        internal static readonly CustomerParameter CustomerBody = new CustomerParameter
        {
            ReferenceId = "demo_1475801962607",
            GivenNames = "John",
            MobileNumber = "+6287774441111",
            Email = "customer@website.com",
        };

        internal static readonly CustomerResponse[] ExpectedCustomers = new CustomerResponse[] { ExpectedCustomerData };
        internal static readonly string CustomerIdUrl = string.Format("{0}?reference_id={1}", CustomerUrl, ExpectedCustomerData.ReferenceId);

        internal static readonly CustomerResponse ExpectedCustomerNewApiVersion = new CustomerResponse
        {
            HasMore = false,
            Data = new CustomerResponse[] { ExpectedCustomerData },
        };

        internal static readonly string ApiKey = "api-key";
        internal static readonly string BaseUrl = "https://api.xendit.co";
    }
}
