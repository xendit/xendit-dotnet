namespace Xendit.net.Model.Invoice
{
    using System.Threading.Tasks;
    using Xendit.net.Struct;

    public class Invoice
    {
        /// <summary>
        /// Create invoice with parameters and headers.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="InvoiceParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#create-invoice"/>.</param>
        /// <returns>A Task of <see cref="InvoiceResponse"/>.</returns>
        public static async Task<InvoiceResponse> Create(InvoiceParameter parameter, HeaderParameter? headers = null)
        {
            return await CreateRequest(parameter, headers);
        }

        /// <summary>
        /// Get invoice detail by ID.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to retrieve.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#get-invoice"/></param>
        /// <returns>A Task of <see cref="InvoiceResponse"/>.</returns>
        public static async Task<InvoiceResponse> GetById(string invoiceId, HeaderParameter? headers = null)
        {
            return await GetByIdRequest(invoiceId, headers);
        }

        /// <summary>
        /// Get all invoices by given parameters.
        /// </summary>
        /// <param name="parameter">Parameter listed here <see cref="ListInvoiceParameter"/>.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see cref="https://developers.xendit.co/api-reference/#list-all-invoices"/>.</param>
        /// <returns>A Task of <see cref="InvoiceResponse[]"/>.</returns>
        public static async Task<InvoiceResponse[]> GetAll(ListInvoiceParameter? parameter = null, HeaderParameter? headers = null)
        {
            ListInvoiceParameter validParameter = parameter ?? new ListInvoiceParameter { };
            return await GetAllRequest(validParameter, headers);
        }

        /// <summary>
        /// Expire an already created invoice.
        /// </summary>
        /// <param name="invoiceId">ID of the invoice to be expired / canceled.</param>
        /// <param name="headers">Custom headers <see cref="HeaderParameter"/>. Use property based on <see href="https://developers.xendit.co/api-reference/#expire-invoice"/>.</param>
        /// <returns>A Task of <see cref="Invoice"/>.</returns>
        public static async Task<InvoiceResponse> Expire(string invoiceId, HeaderParameter? headers = null)
        {
            return await ExpireRequest(invoiceId, headers);
        }

        private static async Task<InvoiceResponse> CreateRequest(InvoiceParameter parameter, HeaderParameter? headers)
        {
            InvoiceClient client = new InvoiceClient();
            return await client.Create(parameter, headers);
        }

        private static async Task<InvoiceResponse> GetByIdRequest(string invoiceId, HeaderParameter? headers)
        {
            InvoiceClient client = new InvoiceClient();
            return await client.GetById(invoiceId, headers);
        }

        private static async Task<InvoiceResponse[]> GetAllRequest(ListInvoiceParameter queryParams, HeaderParameter? headers)
        {
            InvoiceClient client = new InvoiceClient();
            return await client.GetAll(queryParams, headers);
        }

        private static async Task<InvoiceResponse> ExpireRequest(string invoiceId, HeaderParameter? headers)
        {
            InvoiceClient client = new InvoiceClient();
            return await client.Expire(invoiceId, headers);
        }
    }
}
