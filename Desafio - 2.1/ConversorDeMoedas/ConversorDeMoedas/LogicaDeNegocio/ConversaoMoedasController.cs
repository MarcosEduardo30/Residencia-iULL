using ConversorDeMoedas.Entidades;
using System.Text.Json;

namespace ConversorDeMoedas.LogicaDeNegocio
{
    public static class ConversaoMoedasController
    {
        public static List<string> ValidarInput(string MoedaOrigem, string ValorOrigem, string MoedaDestino)
        {
            double ValorDouble;
            List<string> erros = [];

            //Validações das siglas das moedas
            if (MoedaOrigem.Length != 3 || MoedaDestino.Length != 3)
                erros.Add("Erro: Siglas das moedas de origem e destino devem possuir 3 letras!");
            if (MoedaOrigem.Any(char.IsDigit) || MoedaDestino.Any(char.IsDigit))
                erros.Add("Erro: Sigla das moedas não podem conter números!");
            if (MoedaOrigem == MoedaDestino)
                erros.Add("Erro: Moeda de origem e de destino não podem ser a mesma");
            //Validações do valor digitado
            if (!double.TryParse(ValorOrigem, out ValorDouble))
                erros.Add("Erro: valor a ser convertido inválido! Digite apenas números por favor");
            if (ValorDouble < 0)
                erros.Add("Erro: valor a ser convertido deve ser maior que 0!");
            return erros;
        }

        public static async Task<ConversaoMoedas> ConverterMoedas(string MoedaOrigem, string ValorOrigem, string MoedaDestino)
        {
            using HttpClient client = new HttpClient();
            Uri endpoint = new Uri($"https://v6.exchangerate-api.com/v6/0354d15f24a5b90b35e05e67/pair/{MoedaOrigem}/{MoedaDestino}/{ValorOrigem}");
            HttpResponseMessage response = await client.GetAsync(endpoint);

            var conversao = await JsonSerializer.DeserializeAsync<ConversaoMoedas>(await response.Content.ReadAsStreamAsync());

            if (conversao.Resultado == "error")
            {
                throw new Exception(conversao.erro);
            }

            conversao.valorOrigem = double.Parse(ValorOrigem.Replace(".", ","));
            return conversao;
        }
    }
}
