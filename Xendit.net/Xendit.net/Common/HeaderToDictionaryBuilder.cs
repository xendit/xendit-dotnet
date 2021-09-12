namespace Xendit.net.Common
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Xendit.net.Struct;

    public class HeaderToDictionaryBuilder
    {
        public static Dictionary<string, string> Build(HeaderParameter? parameter)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            if (parameter == null)
            {
                return headers;
            }

            PropertyInfo[] info = parameter.GetType().GetProperties();

            foreach (PropertyInfo property in info)
            {
                if (property.GetValue(parameter) != null)
                {
                    string propertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>(true).Name;
                    string serializedValue = JsonSerializer.Serialize(property.GetValue(parameter), new JsonSerializerOptions { IgnoreNullValues = true });
                    serializedValue = JsonSerializer.Deserialize<string>(serializedValue);
                    headers.Add(propertyName, serializedValue);
                }
            }

            return headers;
        }
    }
}
