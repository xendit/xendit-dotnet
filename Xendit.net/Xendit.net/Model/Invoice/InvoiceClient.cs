namespace Xendit.net.Model.Invoice
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net.Common;
    using Xendit.net.Network;
    using Xendit.net.Struct;

    public class InvoiceClient : BaseClient
    {
        public InvoiceClient(string apiKey = null, INetworkClient requestClient = null, string baseUrl = null)
            : base(apiKey, requestClient, baseUrl)
        {
        }

        /// <summary>
        /// Create invoice with parameters and headers.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InvoiceParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-invoice"/>.</param>
        /// <returns>A Task of <see cref="InvoiceResponse"/>.</returns>
        public async Task<InvoiceResponse> Create(InvoiceParameter parameter, HeaderParameter? headers = null)
        {
            return await this.CreateRequest(parameter, headers);
        }

        /// <summary>
        /// Get invoice detail by ID.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-invoice"/></param>
        /// <returns>A Task of <see cref="InvoiceResponse"/>.</returns>
        public async Task<InvoiceResponse> GetById(string invoiceId, HeaderParameter? headers = null)
        {
            return await this.GetByIdRequest(invoiceId, headers);
        }

        /// <summary>
        /// Get all invoices by given parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="ListInvoiceParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see cref="https://developers.xendit.co/api-reference/#list-all-invoices"/>.</param>
        /// <returns>A Task of <see cref="InvoiceResponse[]"/>.</returns>
        public async Task<InvoiceResponse[]> GetAll(ListInvoiceParameter? parameter = null, HeaderParameter? headers = null)
        {
            string queryParams = parameter != null ? QueryParamsBuilder.Build(parameter) : string.Empty;
            return await this.GetAllRequest(queryParams, headers);
        }

        /// <summary>
        /// Expire an already created invoice.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to be expired / canceled.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#expire-invoice"/>.</param>
        /// <returns>A Task of <see cref="Invoice"/>.</returns>
        public async Task<InvoiceResponse> Expire(string invoiceId, HeaderParameter? headers = null)
        {
            return await this.ExpireRequest(invoiceId, headers);
        }

        private async Task<InvoiceResponse> CreateRequest(InvoiceParameter parameter, HeaderParameter? headers)
        {
            string url = "/v2/invoices";
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<InvoiceParameter, InvoiceResponse>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, parameter, headers);
        }

        private async Task<InvoiceResponse> GetByIdRequest(string invoiceId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/v2/invoices/", invoiceId);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<InvoiceResponse>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }

        private async Task<InvoiceResponse[]> GetAllRequest(string queryParams, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}", "/v2/invoices?", queryParams);
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<InvoiceResponse[]>(HttpMethod.Get, url, this.ApiKey, this.BaseUrl, headers);
        }

        private async Task<InvoiceResponse> ExpireRequest(string invoiceId, HeaderParameter? headers)
        {
            string url = string.Format("{0}{1}{2}", "/invoices/", invoiceId, "/expire!");
            var client = this.requestClient ?? XenditConfiguration.RequestClient;
            return await client.Request<Dictionary<string, string>, InvoiceResponse>(HttpMethod.Post, url, this.ApiKey, this.BaseUrl, new Dictionary<string, string>(), headers);
        }
    }
}
