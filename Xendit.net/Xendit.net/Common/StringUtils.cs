namespace Xendit.net.Common
{
    using System.Linq;

    public static class StringUtils
    {
        public static string ToScreamingSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToUpper();
        }
    }
}
