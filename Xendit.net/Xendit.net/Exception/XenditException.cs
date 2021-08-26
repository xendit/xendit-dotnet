namespace Xendit.net.Exception
{
    public class XenditException : System.Exception
    {
        public XenditException()
        {
        }

        public XenditException(string message)
            : base(message)
        {
        }

        public XenditException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        public XenditException(string message, string errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
