namespace Xendit.net.Model.Balance
{
    using System.Text.Json.Serialization;

    public class BalanceResponse
    {
        [JsonPropertyName("balance")]
        public long Balance { get; set; }
    }
}
