using System.Text.Json.Serialization;

namespace ConversorDeMoedas.Entidades
{
    public record class Conversor(
        [property: JsonPropertyName("result")] string Resultado,
        [property: JsonPropertyName("base_code")] string MoedaOrigem,
        [property: JsonPropertyName("conversion_rates")] TaxasDeConversao Taxas
        );
}
