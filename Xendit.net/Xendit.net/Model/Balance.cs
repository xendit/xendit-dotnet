using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Xendit.net.Exception;
using System.Net.Http;

namespace Xendit.net.Model
{
    public class Balance
    {
        [JsonPropertyName("balance")]
        public int Value { get; set; }
        
        public enum AccountType
        {
            Cash,
            Holding,
            Tax
        }

        /// <summary>
        /// Get balance from your account
        /// </summary>
        /// <returns>A Task that contains balance</returns>
        public static Task<Balance> Get()
        {
            return GetBalanceAsync(new Dictionary<string, string>(), null);
        }

        /// <summary>
        /// Get balance from your account based on given account type
        /// </summary>
        /// <param name="accountType">Selected balance type (in enum)</param>
        /// <returns>A Task that contains balance</returns>
        public static Task<Balance> Get(AccountType accountType)
        {
            return GetBalanceAsync(new Dictionary<string, string>(), accountType);
        }

        /// <summary>
        /// Get balance from your account based on given account type string (Cash, Holding, Tax)
        /// </summary>
        /// <param name="accountTypeValue">Selected balance type in string ("Cash", "Holding", "Tax")</param>
        /// <exception cref="ArgumentException">Thrown when account type value is not "Cash", "Holding", "Tax"</exception>
        /// <returns>A Task that contains balance</returns>
        public static Task<Balance> Get(string accountTypeValue)
        {
            try
            {
                AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), accountTypeValue);
                return GetBalanceAsync(new Dictionary<string, string>(), accountType);
            }
            catch (ArgumentException)
            {
                throw new ParamException("Value should be Cash, Holding, or Tax");
            }
        }

        /// <summary>
        /// Get balance from your account based on given account type with custom headers
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id"</param>
        /// <param name="accountType">Selected balance type (in enum)</param>
        /// <returns>A Task that contains balance</returns>
        public static Task<Balance> Get(Dictionary<string, string> headers, AccountType accountType)
        {
            return GetBalanceAsync(headers, accountType);
        }

        /// <summary>
        /// Get balance from your account based on given account type string (Cash, Holding, Tax) with custom headers
        /// </summary>
        /// <param name="headers">Custom headers. e.g: "for-user-id"</param>
        /// <param name="accountTypeValue">Selected balance type in string ("Cash", "Holding", "Tax")</param>
        /// <exception cref="ArgumentException">Thrown when account type value is not "Cash", "Holding", "Tax"</exception>
        /// <returns>A Task that contains balance</returns>
        public static Task<Balance> Get(Dictionary<string, string> headers, string accountTypeValue)
        {
            try
            {
                AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), accountTypeValue);
                return GetBalanceAsync(headers, accountType);
            }
            catch (ArgumentException)
            {
                throw new ParamException("Value should be Cash, Holding, or Tax");
            }
        }

        private static async Task<Balance> GetBalanceAsync(Dictionary<string, string> headers, AccountType? accountType)
        {
            string url = string.Format("{0}{1}", XenditConfiguration.ApiUrl, "/balance");

            if (accountType != null)
            {
                string accountTypeParam = accountType.ToString().ToUpper();
                url = string.Format("{0}{1}{2}", url, "?account_type=", accountTypeParam);
            }

            var balance = await XenditConfiguration.RequestClient.Request<Balance>(HttpMethod.Get, headers, url, null);
            return balance;
        }
    }
}
