namespace Xendit.net.Common
{
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class QueryParamsBuilder
    {
        public static string Build<T>(T parameter)
        {
            StringBuilder queryParams = new StringBuilder();

            PropertyInfo[] info = parameter.GetType().GetProperties();

            foreach (PropertyInfo property in info)
            {
                if (property.GetValue(parameter) != null)
                {
                    string propertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>(true).Name;
                    string serializedValue = JsonSerializer.Serialize(property.GetValue(parameter), new JsonSerializerOptions { IgnoreNullValues = true });
                    queryParams.AppendFormat("&{0}={1}", propertyName, serializedValue);
                }
            }

            return queryParams.ToString();
        }
    }
}
