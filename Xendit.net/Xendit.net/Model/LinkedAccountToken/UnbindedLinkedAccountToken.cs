namespace Xendit.net.Model.LinkedAccountToken
{
    using System.Text.Json.Serialization;

    public class UnbindedLinkedAccountToken
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
