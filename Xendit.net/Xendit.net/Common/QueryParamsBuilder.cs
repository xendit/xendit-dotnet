namespace Xendit.net.Common
{
    using System.Collections.Generic;

    public class QueryParamsBuilder
    {
        public static string Build(string[] paramList, Dictionary<string, object> parameter)
        {
            string queryParams = string.Empty;

            for (int i = 0; i < paramList.Length; i++)
            {
                string key = paramList[i];
                if (parameter.ContainsKey(key))
                {
                    queryParams += string.Format("{0}{1}{2}{3}", "&", key, "=", parameter[key]);
                }
            }

            return queryParams;
        }
    }
}
