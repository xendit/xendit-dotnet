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

        public static async Task<Disbursement> Create(Dictionary<string, object> parameter)
        {
            return await CreateDisbursementRequest(new Dictionary<string, string>(), parameter);
        }

        public static async Task<Disbursement> Create(Dictionary<string, string> headers, Dictionary<string, object> parameter)
        {
            return await CreateDisbursementRequest(headers, parameter);
        }

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

        public static async Task<Disbursement> GetById(string id)
        {
            return await GetById(new Dictionary<string, string>(), id);
        }

        public static async Task<Disbursement> GetById(Dictionary<string, string> headers, string id)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements/", id);

            var disbursement = await XenditConfiguration.RequestClient.Request<Disbursement>(HttpMethod.Get, headers, url, null);
            return disbursement;
        }

        public static async Task<Disbursement[]> GetByExternalId(string externalId)
        {
            return await GetByExternalId(new Dictionary<string, string>(), externalId);
        }

        public static async Task<Disbursement[]> GetByExternalId(Dictionary<string, string> headers, string externalId)
        {
            string url = string.Format("{0}{1}{2}", XenditConfiguration.ApiUrl, "/disbursements?external_id=", externalId);

            var disbursement = await XenditConfiguration.RequestClient.Request<Disbursement[]>(HttpMethod.Get, headers, url, null);
            return disbursement;
        }

        public static async Task<AvailableBank[]> GetAvailableBanks()
        {
            return await GetAvailableBanks(new Dictionary<string, string>());
        }

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
