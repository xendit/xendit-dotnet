namespace Xendit.net.Model.VirtualAccount
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class VirtualAccount
    {
        /// <summary>
        /// Create Virtual Account with complete parameter.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="CreateVirtualAccountParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see cref="https://developers.xendit.co/api-reference/#create-fixed-virtual-accounts"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public static async Task<VirtualAccountResponse> Create(CreateVirtualAccountParameter parameter, HeaderParameter? headers = null)
        {
            VirtualAccountClient client = new VirtualAccountClient();
            return await client.Create(parameter, headers);
        }

        /// <summary>
        /// Get Virtual Account based on its ID.
        /// </summary>
        /// <param name="id">ID of the virtual account to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public static async Task<VirtualAccountResponse> Get(string id, HeaderParameter? headers = null)
        {
            VirtualAccountClient client = new VirtualAccountClient();
            return await client.Get(id, headers);
        }

        /// <summary>
        /// Update Virtual Account based on its ID.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="UpdateVirtualAccountParameter"/>.</param>
        /// <param name="id">ID of the fixed virtual account to update.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#update-fixed-virtual-account"/>.</param>
        /// <returns>A Task of <see cref="VirtualAccountResponse"/>.</returns>
        public static async Task<VirtualAccountResponse> Update(UpdateVirtualAccountParameter parameter, string id, HeaderParameter? headers = null)
        {
            VirtualAccountClient client = new VirtualAccountClient();
            return await client.Update(parameter, id, headers);
        }

        /// <summary>
        /// Get Virtual Account available banks.
        /// </summary>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-virtual-account-banks"/>.</param>
        /// <returns>A Task of <see cref="AvailableBank[]"/>.</returns>
        public static async Task<AvailableBank[]> GetAvailableBanks(HeaderParameter? headers = null)
        {
            VirtualAccountClient client = new VirtualAccountClient();
            return await client.GetAvailableBanks();
        }
    }
}
