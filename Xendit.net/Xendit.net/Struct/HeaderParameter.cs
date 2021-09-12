namespace Xendit.net.Struct
{
    using System.Text.Json.Serialization;
    using Xendit.net.Enum;

    public struct HeaderParameter
    {
        [JsonPropertyName("for-user-id")]
        public string ForUserId { get; set; }

        [JsonPropertyName("with-fee-rule")]
        public string WithFeeRule { get; set; }

        [JsonPropertyName("X-IDEMPOTENCY-KEY")]
        public string XIdempotencyKey { get; set; }

        [JsonPropertyName("Idempotency-key")]
        public string Idempotencykey { get; set; }

        [JsonPropertyName("IDEMPOTENCY-KEY")]
        public string IdempotencyKey { get; set; }

        [JsonPropertyName("API-VERSION")]
        public ApiVersion? ApiVersion { get; set; }
    }
}
