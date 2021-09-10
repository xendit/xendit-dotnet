namespace Xendit.net.Common
{
    using Xendit.net.Enum;

    public class ApiVersionParser
    {
        public static string Parse(ApiVersion apiVersion)
        {
            string result = string.Empty;
            switch (apiVersion)
            {
                case ApiVersion.Version20201031:
                    result = "2020-10-31";
                    break;
                case ApiVersion.Version20200519:
                    result = "2020-05-19";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
