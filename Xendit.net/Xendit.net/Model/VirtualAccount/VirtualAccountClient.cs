namespace Xendit.net.Model.VirtualAccount
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class VirtualAccountClient : BaseClient
    {
        public VirtualAccountClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create Virtual Account with complete parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CreateVirtualAccountParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see cref="https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public async Task<VirtualAccountResponse> Create(CreateVirtualAccountParameter parameter, HeaderParameter? headers = null)
        {
            string url = "/callback_virtual_accounts";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<CreateVirtualAccountParameter, VirtualAccountResponse>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        /// <summary>
        /// Get Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the virtual account to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public async Task<VirtualAccountResponse> Get(string id, HeaderParameter? headers = null)
        {
            string url = string.Format("{0}{1}", "/callback_virtual_accounts/", id);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<VirtualAccountResponse>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }

        /// <summary>
        /// Update Virtual Account based on its ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="UpdateVirtualAccountParameter"/>.</param>
        /// <param name="id">ID of the fixed virtual account to update.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#update-fixed-virtual-account"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public async Task<VirtualAccountResponse> Update(UpdateVirtualAccountParameter parameter, string id, HeaderParameter? headers = null)
        {
            string url = string.Format("{0}{1}", "/callback_virtual_accounts/", id);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<UpdateVirtualAccountParameter, VirtualAccountResponse>(XenditHttpMethod.Patch, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        /// <summary>
        /// Get Virtual Account available banks.
        /// </summary>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account-banks"/>.</param>
        /// <returns>A Task of <see cref="AvailableBank[]"/>.</returns>
        public async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            string url = "/available_virtual_account_banks";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<AvailableBank[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }
    }
}
