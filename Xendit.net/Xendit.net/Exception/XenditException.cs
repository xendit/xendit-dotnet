using System.Collections.Generic;

namespace Xendit.net.Exception
{
    public class XenditException : System.Exception
    {
        public XenditException()
        {
        }

        public XenditException(string message) : base(message)
        {
        }

        public XenditException(string message, System.Exception inner) : base(message, inner)
        {
        }

        public XenditException(string message, string errorCode, Dictionary<string, object> context) : base(message)
        {
            this.ErrorCode = errorCode;
            this.Context = context;
        }

        public string ErrorCode { get; set; }

        public Dictionary<string, object> Context { get; set; }
    }
}
