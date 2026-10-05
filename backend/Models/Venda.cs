using System.Text.Json.Serialization;

namespace TargetApi.Models
{
    public class Venda
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("vendedor")]
        public string? Vendedor { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

    }
}
