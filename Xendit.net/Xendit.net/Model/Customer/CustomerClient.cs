namespace Xendit.net.Model.Customer
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class CustomerClient : BaseClient
    {
        public CustomerClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create customer with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CustomerParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-customer"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="CustomerResponse"/>.</returns>
        public async Task<CustomerResponse> Create(CustomerParameter parameter, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.ApiVersion = version;

            string url = "/customers";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<CustomerParameter, CustomerResponse>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, validHeaders);
        }

        /// <summary>
        /// Get customer by reference ID.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-customer-by-reference-id"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="CustomerResponse[]"/>.</returns>
        public async Task<CustomerResponse> Get(string referenceId, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.ApiVersion = version;

            string url = string.Format("{0}{1}", "/customers?reference_id=", referenceId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;

            if (validHeaders.ApiVersion == ApiVersion.Version20200519)
            {
                CustomerResponse[] customerData = await client.Request<CustomerResponse[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, validHeaders);
                CustomerResponse customer = new CustomerResponse { Data = customerData };

                return customer;
            }

            return await client.Request<CustomerResponse>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, validHeaders);
        }

        /// <summary>
        /// Update customer with parameters By ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CustomerParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-customer"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// /// <param name="customerId">customerId that we want to updated.</param>
        /// <returns>A Task of <see cref="CustomerResponse"/>.</returns>
        /// <summary>
        public async Task<CustomerResponse> Update(CustomerParameter parameter, string customerId, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            string url = string.Format("{0}{1}", "/customers/", customerId);
            HeaderParameter validHeaders = headers ?? new HeaderParameter { };
            validHeaders.ApiVersion = version;
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<CustomerParameter, CustomerResponse>(XenditHttpMethod.Patch, url, this.ApiKey, this.BaseUrl, parameter, validHeaders);
        }
    }
}
