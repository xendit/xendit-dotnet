namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

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
        public string Type { get; set; }

        [JsonPropertyName("individual_detail")]
        public CustomerIndividualDetail IndividualDetail { get; set; }

        [JsonPropertyName("business_detail")]
        public CustomerBusinessDetail BusinessDetail { get; set; }

        [JsonPropertyName("identity_accounts")]
        public CustomerIdentityAccount[] IdentityAccount { get; set; }

        [JsonPropertyName("kyc_documents")]
        public CustomerKycDocument[] KycDocuments { get; set; }

        /// <summary>
        /// Create customer with required parameters for API version 2020-05-19.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="givenNames"> Primary of first name/s of the customer.</param>
        /// <param name="mobileNumber">Mobile number of the customer in E.164 international standard.</param>
        /// <param name="email">Email address of the customer.</param>
        /// <returns>A Task of Customer model.</returns>
        public static async Task<Customer> Create(string referenceId, string givenNames, string mobileNumber, string email)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("API-VERSION", "2020-05-19");

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("reference_id", referenceId);
            parameter.Add("given_names", givenNames);
            parameter.Add("mobile_number", mobileNumber);
            parameter.Add("email", email);

            return await CreateCustomerRequest(headers, parameter);
        }

        /// <summary>
        /// Create customer with required parameters and headers for API version 2020-05-19.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="givenNames"> Primary of first name/s of the customer.</param>
        /// <param name="mobileNumber">Mobile number of the customer in E.164 international standard.</param>
        /// <param name="email">Email address of the customer.</param>
        /// <returns>A Task of Customer model.</returns>
        public static async Task<Customer> Create(Dictionary<string, string> headers, string referenceId, string givenNames, string mobileNumber, string email)
        {
            headers.Add("API-VERSION", "2020-05-19");

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("reference_id", referenceId);
            parameter.Add("given_names", givenNames);
            parameter.Add("mobile_number", mobileNumber);
            parameter.Add("email", email);

            return await CreateCustomerRequest(headers, parameter);
        }

        /// <summary>
        /// Create customer with complete parameters in dictionary.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-customer.</param>
        /// <returns>A Task of Customer model.</returns>
        public static async Task<Customer> Create(Dictionary<string, object> parameter)
        {
            return await CreateCustomerRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create customer with complete parameters in dictionary and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-customer.</param>
        /// <returns>A Task of Customer model.</returns>
        public static async Task<Customer> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return await CreateCustomerRequest(headers, parameter);
        }

        /// <summary>
        /// Get customer by reference id.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <returns>A Task of customers array.</returns>
        public static async Task<Customer[]> GetByReferenceId(string referenceId)
        {
            return await GetByReferenceIdRequest(new Dictionary<string, string>(), referenceId);
        }

        /// <summary>
        /// Get customer by reference id with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <returns>A Task of customers array.</returns>
        public static async Task<Customer[]> GetByReferenceId(Dictionary<string, string> headers, string referenceId)
        {
            return await GetByReferenceIdRequest(headers, referenceId);
        }

        private static async Task<Customer> CreateCustomerRequest(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}/{1}", XenditConfiguration.ApiUrl, "customers");
            return await XenditConfiguration.RequestClient.Request<Customer>(HttpMethod.Post, headers, url, parameter);
        }

        private static async Task<Customer[]> GetByReferenceIdRequest(Dictionary<string, string> headers, string referenceId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/customers?reference_id=", referenceId);
            return await XenditConfiguration.RequestClient.Request<Customer[]>(HttpMethod.Get, headers, url, null);
        }
    }
}
