using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xendit.net.Exception;

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

        public static Task<Balance> Get()
        {
            return GetBalanceAsync(new Dictionary<string, string>(), null);
        }
        
        public static Task<Balance> Get(AccountType accountType)
        {
            return GetBalanceAsync(new Dictionary<string, string>(), accountType);
        }

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

        public static Task<Balance> Get(Dictionary<string, string> headers, AccountType accountType)
        {
            return GetBalanceAsync(headers, accountType);
        }

        public static Task<Balance> Get(Dictionary<string, string> headers, string accountTypeValue)
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

        public static async Task<Balance> GetBalanceAsync(Dictionary<string, string> headers, AccountType? accountType)
        {
            string url = string.Format("{0}{1}", Xendit.ApiUrl, "/balance");

            if (accountType != null)
            {
                string accountTypeParam = accountType.ToString().ToUpper();
                url = string.Format("{0}{1}{2}", url, "?account_type=", accountTypeParam);
            }

            var result = await Xendit.requestClient.Request(headers, url);
            var balance = await JsonSerializer.DeserializeAsync<Balance>(result);
            return balance;
        }
    }
}
