namespace Xendit.net.Network
{
    using System.Net.Http;

    public class XenditHttpMethod : HttpMethod
    {
        private static readonly HttpMethod PatchMethod = new HttpMethod("PATCH");

        public XenditHttpMethod(string method)
            : base(method)
        {
        }

        /// <summary>
        /// Gets an HTTP PATCH protocol method to accomodate Net Standard 2.0 which doesn't have PATCH getter.
        /// </summary>
        /// <returns>A System.Net.Http.HttpMethod object.</return>
        public static new HttpMethod Patch
        {
            get { return PatchMethod; }
        }
    }
}
