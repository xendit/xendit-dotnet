namespace Xendit.net.Model
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Numerics;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Xendit.net.Common;

    public class Disbursement
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonConverter(typeof(BigIntegerConverter))]
        [JsonPropertyName("amount")]
        public BigInteger Amount { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonPropertyName("disbursement_description")]
        public string DisbursementDescription { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("email_to")]
        public string[] EmailTo { get; set; }

        [JsonPropertyName("email_cc")]
        public string[] EmailCC { get; set; }

        [JsonPropertyName("email_bcc")]
        public string[] EmailBCC { get; set; }

        /// <summary>
        /// Create disbursement with all parameter as dictionary.
        /// </summary>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(Dictionary<string, object> parameter)
        {
            return await CreateDisbursementRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create disbursement with all parameter as dictionary with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="parameter">Parameter listed here https://developers.xendit.co/api-reference/#create-disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return await CreateDisbursementRequest(headers, parameter);
        }

        /// <summary>
        /// Create disbursement with required parameters.
        /// </summary>
        /// <param name="externalId">ID of the disbursement in your system, used to reconcile disbursements after they have been completed.</param>
        /// <param name="bankCode">Code of the destination bank.</param>
        /// <param name="accountHolderName">Name of account holder as per the bank's or e-wallet's records used for verification and error/customer support scenarios.</param>
        /// <param name="accountNumber">Destination bank account number. If disbursing to an e-wallet, phone number registered with the e-wallet account.</param>
        /// <param name="description">Description to send with the disbursement.</param>
        /// <param name="amount">Amount to disburse.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(string externalId, string bankCode, string accountHolderName, string accountNumber, string description, BigInteger amount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "account_holder_name", accountHolderName },
                { "account_number", accountNumber },
                { "description", description },
                { "amount", amount },
            };
            return await CreateDisbursementRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create disbursement with required parameters and headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">ID of the disbursement in your system, used to reconcile disbursements after they have been completed.</param>
        /// <param name="bankCode">Code of the destination bank.</param>
        /// <param name="accountHolderName">Name of account holder as per the bank's or e-wallet's records used for verification and error/customer support scenarios.</param>
        /// <param name="accountNumber">Destination bank account number. If disbursing to an e-wallet, phone number registered with the e-wallet account.</param>
        /// <param name="description">Description to send with the disbursement.</param>
        /// <param name="amount">Amount to disburse.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(Dictionary<string, string> headers, string externalId, string bankCode, string accountHolderName, string accountNumber, string description, BigInteger amount)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                { "external_id", externalId },
                { "bank_code", bankCode },
                { "account_holder_name", accountHolderName },
                { "account_number", accountNumber },
                { "description", description },
                { "amount", amount },
            };
            return await CreateDisbursementRequest(headers, parameter);
        }

        /// <summary>
        /// Create disbursement with required parameters and and can accept additional params.
        /// </summary>
        /// <param name="externalId">ID of the disbursement in your system, used to reconcile disbursements after they have been completed.</param>
        /// <param name="bankCode">Code of the destination bank.</param>
        /// <param name="accountHolderName">Name of account holder as per the bank's or e-wallet's records used for verification and error/customer support scenarios.</param>
        /// <param name="accountNumber">Destination bank account number. If disbursing to an e-wallet, phone number registered with the e-wallet account.</param>
        /// <param name="description">Description to send with the disbursement.</param>
        /// <param name="amount">Amount to disburse.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(string externalId, string bankCode, string accountHolderName, string accountNumber, string description, BigInteger amount, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("account_holder_name", accountHolderName);
            parameter.Add("account_number", accountNumber);
            parameter.Add("description", description);
            parameter.Add("amount", amount);

            return await CreateDisbursementRequest(new Dictionary<string, string>(), parameter);
        }

        /// <summary>
        /// Create disbursement with required parameters and and can accept additional params, with custom headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">ID of the disbursement in your system, used to reconcile disbursements after they have been completed.</param>
        /// <param name="bankCode">Code of the destination bank.</param>
        /// <param name="accountHolderName">Name of account holder as per the bank's or e-wallet's records used for verification and error/customer support scenarios.</param>
        /// <param name="accountNumber">Destination bank account number. If disbursing to an e-wallet, phone number registered with the e-wallet account.</param>
        /// <param name="description">Description to send with the disbursement.</param>
        /// <param name="amount">Amount to disburse.</param>
        /// <param name="parameter">Optional params. Check https://developers.xendit.co/api-reference/#create-disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> Create(Dictionary<string, string> headers, string externalId, string bankCode, string accountHolderName, string accountNumber, string description, BigInteger amount, Dictionary<string, object> parameter)
        {
            parameter.Add("external_id", externalId);
            parameter.Add("bank_code", bankCode);
            parameter.Add("account_holder_name", accountHolderName);
            parameter.Add("account_number", accountNumber);
            parameter.Add("description", description);
            parameter.Add("amount", amount);

            return await CreateDisbursementRequest(headers, parameter);
        }

        /// <summary>
        /// Get disbursement object by ID.
        /// </summary>
        /// <param name="id">ID of disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> GetById(string id)
        {
            return await GetById(new Dictionary<string, string>(), id);
        }

        /// <summary>
        /// Get disbursement object by ID with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="id">ID of disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement> GetById(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements/", id);

            var disbursement = await XenditConfiguration.RequestClient.Request<Disbursement>(HttpMethod.Get, headers, url, null);
            return disbursement;
        }

        /// <summary>
        /// Get disbursement object by external ID.
        /// </summary>
        /// <param name="externalId">External ID of disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement[]> GetByExternalId(string externalId)
        {
            return await GetByExternalId(new Dictionary<string, string>(), externalId);
        }

        /// <summary>
        /// Get disbursement object by external ID with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <param name="externalId">External ID of disbursement.</param>
        /// <returns>A Task of Disbursement model.</returns>
        public static async Task<Disbursement[]> GetByExternalId(Dictionary<string, string> headers, string externalId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements?external_id=", externalId);

            var disbursement = await XenditConfiguration.RequestClient.Request<Disbursement[]>(HttpMethod.Get, headers, url, null);
            return disbursement;
        }

        /// <summary>
        /// Get available banks for disbursement.
        /// </summary>
        /// <returns>A Task of array of Available Banks.</returns>
        public static async Task<AvailableBank[]> GetAvailableBanks()
        {
            return await GetAvailableBanks(new Dictionary<string, string>());
        }

        /// <summary>
        /// Get available banks for disbursement with headers.
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id".</param>
        /// <returns>A Task of array of Available Banks.</returns>
        public static async Task<AvailableBank[]> GetAvailableBanks(Dictionary<string, string> headers)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/available_disbursements_banks");

            var availableBanks = await XenditConfiguration.RequestClient.Request<AvailableBank[]>(HttpMethod.Get, headers, url, null);
            return availableBanks;
        }

        private static async Task<Disbursement> CreateDisbursementRequest(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/disbursements");

            var disbursement = await XenditConfiguration.RequestClient.Request<Disbursement>(HttpMethod.Post, headers, url, parameter);
            return disbursement;
        }
    }
}
