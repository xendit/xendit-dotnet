namespace Xendit.net.Common
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException(string.Format("Found token {0} but expected token {1}", reader.TokenType, JsonTokenType.Number));
            }

            var doc = JsonDocument.ParseValue(ref reader);
            return BigInteger.Parse(doc.RootElement.GetRawText(), NumberFormatInfo.InvariantInfo);
        }

        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            string convertedValue = value.ToString(NumberFormatInfo.InvariantInfo);
            var doc = JsonDocument.Parse(convertedValue);
            doc.WriteTo(writer);
        }
    }
}
