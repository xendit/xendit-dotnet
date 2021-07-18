namespace Xendit.net.Exception
{
    using System.Collections.Generic;

    public class ApiException : XenditException
    {
        public ApiException(string message, string code, Dictionary<string, object> requestBody)
        : base(message, code, requestBody)
        {
        }
    }
}
