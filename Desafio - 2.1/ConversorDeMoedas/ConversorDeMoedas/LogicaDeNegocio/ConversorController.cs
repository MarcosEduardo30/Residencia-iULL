using ConversorDeMoedas.Entidades;
using System.Text.Json;

namespace ConversorDeMoedas.LogicaDeNegocio
{
    public static class ConversorController
    {
        public static async Task<Conversor> CriaConversor(string MoedaOrigem)
        {
            using HttpClient client = new HttpClient();
            Uri endpoint = new Uri("https://v6.exchangerate-api.com/v6/0354d15f24a5b90b35e05e67/latest/" + MoedaOrigem);
            await using Stream stream = await client.GetStreamAsync(endpoint);
            var conversor = await JsonSerializer.DeserializeAsync<Conversor>(stream);
            return conversor;
        }
    }
}
