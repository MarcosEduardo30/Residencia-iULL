using System.Text.Json.Serialization;

namespace ConversorDeMoedas.Entidades
{
    public record class ConversaoMoedas(
        [property: JsonPropertyName("result")] string Resultado,
        [property: JsonPropertyName("base_code")] string MoedaOrigem,
        [property: JsonPropertyName("target_code")] string MoedaDestino,
        [property: JsonPropertyName("conversion_rate")] double Taxa,
        [property: JsonPropertyName("conversion_result")] double ValorConversao,
        [property: JsonPropertyName("error-type")] string erro
        )
    {
        public double valorOrigem { get; set; }
    }
}
