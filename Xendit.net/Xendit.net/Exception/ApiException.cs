using System;
using System.Collections.Generic;
using System.Text;

namespace Xendit.net.Exception
{
    public class ApiException : XenditException
    {
        public ApiException(string message, string code, Dictionary<string, object> requestBody)
        : base(message, code, requestBody)
        {
        }
    }
}
