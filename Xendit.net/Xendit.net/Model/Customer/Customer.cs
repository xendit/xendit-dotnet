namespace Xendit.net.Model.Customer
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
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
        public Address[] Addresses { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonPropertyName("type")]
        public CustomerType Type { get; set; }

        [JsonPropertyName("individual_detail")]
        public IndividualDetail IndividualDetail { get; set; }

        [JsonPropertyName("business_detail")]
        public BusinessDetail BusinessDetail { get; set; }

        [JsonPropertyName("identity_accounts")]
        public IdentityAccount[] IdentityAccount { get; set; }

        [JsonPropertyName("kyc_documents")]
        public KycDocument[] KycDocuments { get; set; }

        [JsonPropertyName("data")]
        public Customer[] Data { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        /// <summary>
        /// Create customer with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here .</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-customer"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="Customer"/>.</returns>
        public static async Task<Customer> Create(CustomerParameter parameter, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.ApiVersion = version;

            return await CreateCustomerRequest(parameter, validHeaders);
        }

        /// <summary>
        /// Get customer by reference ID.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-customer-by-reference-id"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="Customer[]"/>.</returns>
        public static async Task<Customer> Get(string referenceId, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.ApiVersion = version;

            return await GetCustomerRequest(referenceId, validHeaders);
        }

        private static async Task<Customer> CreateCustomerRequest(CustomerParameter parameter, HeaderParameter? headers)
        {
            string url = string.Format("{0}/{1}", XenditConfiguration.ApiUrl, "customers");
            return await XenditConfiguration.RequestClient.Request<CustomerParameter, Customer>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<Customer> GetCustomerRequest(string referenceId, HeaderParameter headers)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/customers?reference_id=", referenceId);

            if (headers.ApiVersion == ApiVersion.Version20200519)
            {
                Customer[] customerData = await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Customer[]>(HttpMethod.Get, headers, url, null);
                Customer customer = new Customer { Data = customerData };

                return customer;
            }

            return await XenditConfiguration.RequestClient.Request<Dictionary<string, string>, Customer>(HttpMethod.Get, headers, url, null);
        }
    }
}
