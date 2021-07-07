using System;
using System.Collections.Generic;
using System.Text;

namespace xendit.net.Entities
{
    public class Balance
    {
        private double balance;

        public enum AccountType
        {
            Cash,
            Holding,
            Tax
        }

        public static Balance Get(AccountType accountType)
        {
            return GetBalance(new Dictionary<string, string>(), accountType);
        }

        public static Balance Get(Dictionary<string, string> headers, AccountType accountType)
        {
            return GetBalance(headers, accountType);
        }

        public static Balance GetBalance(Dictionary<string, string> headers, AccountType accountType)
        {
            
        }
    }
}
