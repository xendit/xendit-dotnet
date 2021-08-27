namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Common;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("mobile_number")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("given_names")]
        public string GivenNames { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("addresses")]
        public CustomerAddress[] Addresses { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonPropertyName("type")]
        public CustomerType Type { get; set; }

        [JsonPropertyName("individual_detail")]
        public CustomerIndividualDetail IndividualDetail { get; set; }

        [JsonPropertyName("business_detail")]
        public CustomerBusinessDetail BusinessDetail { get; set; }

        [JsonPropertyName("identity_accounts")]
        public CustomerIdentityAccount[] IdentityAccount { get; set; }

        [JsonPropertyName("kyc_documents")]
        public CustomerKycDocument[] KycDocuments { get; set; }

        [JsonPropertyName("data")]
        public Customer[] Data { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        /// <summary>
        /// Create customer with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-customer.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="version">API version that will be used to request.</param>
        /// <returns>A Task of Customer model.</returns>
        public static async Task<Customer> Create(CustomerBody parameter, Dictionary<string, string> headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            headers = headers ?? new Dictionary<string, string>();
            headers.Add("API-VERSION", ApiVersionParser.Parse(version));

            return await CreateCustomerRequest(headers, parameter);
        }

        /// <summary>
        /// Get customer by reference ID.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="version">API version that will be used to request using ApiVersion enum.</param>
        /// <returns>A Task of customers array.</returns>
        public static async Task<Customer> Get(string referenceId, Dictionary<string, string> headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            headers = headers ?? new Dictionary<string, string>();
            headers.Add("API-VERSION", ApiVersionParser.Parse(version));

            return await GetCustomerRequest(headers, referenceId);
        }

        private static async Task<Customer> CreateCustomerRequest(Dictionary<string, string> headers, CustomerBody parameter)
        {
            string url = string.Format("{0}/{1}", XenditConfiguration.ApiUrl, "customers");
            return await XenditConfiguration.RequestClient.Request<CustomerBody, Customer>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<Customer> GetCustomerRequest(Dictionary<string, string> headers, string referenceId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/customers?reference_id=", referenceId);

            if (headers["API-VERSION"] == "2020-05-19")
            {
                Customer[] customerData = await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Customer[]>(HttpMethod.Get, headers, url, null);
                Customer customer = new Customer { Data = customerData };

                return customer;
            }

            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, headers, url, null);
        }
    }
}
