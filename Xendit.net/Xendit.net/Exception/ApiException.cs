namespace Xendit.net.Exception
{
    public class ApiException : XenditException
    {
        public ApiException(string message, string code)
        : base(message, code)
        {
        }
    }
}
