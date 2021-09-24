namespace Xendit.net.Model.Customer
{
    using System.Threading.Tasks;
    using Xendit.net.Enum;
    using Xendit.net.Struct;

    public class Customer
    {
        /// <summary>
        /// Create customer with parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CustomerParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-customer"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="CustomerResponse"/>.</returns>
        public static async Task<CustomerResponse> Create(CustomerParameter parameter, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            CustomerClient client = new CustomerClient();
            return await client.Create(parameter, headers, version);
        }

        /// <summary>
        /// Get customer by reference ID.
        /// </summary>
        /// <param name="referenceId">Merchant-provided identifier for the customer.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-customer-by-reference-id"/>.</param>
        /// <param name="version">API version that will be used to request <see cref="ApiVersion"/>.</param>
        /// <returns>A Task of <see cref="CustomerResponse[]"/>.</returns>
        public static async Task<CustomerResponse> Get(string referenceId, HeaderParameter? headers = null, ApiVersion version = ApiVersion.Version20201031)
        {
            CustomerClient client = new CustomerClient();
            return await client.Get(referenceId, headers, version);
        }
    }
}
