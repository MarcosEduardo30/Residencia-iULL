using ConversorDeMoedas.Entidades;

namespace ConversorDeMoedas.LogicaDeNegocio
{
    public static class ConversaoMoedasController
    {
        public static List<string> ValidarConversaoMoedas(string MoedaOrigem, double ValorOrigem, string MoedaDestino)
        {
            List<string> erros = [];
            if (MoedaOrigem.Length != 3 || MoedaDestino.Length != 3)
                erros.Add("Erro: Siglas das moedas de origem e destino devem possuir 3 letras!");
            if (MoedaOrigem == MoedaDestino)
                erros.Add("Erro: Moeda de origem e de destino não podem ser a mesma");
            if (ValorOrigem < 0)
                erros.Add("Erro: valor de origem deve ser maior do que 0");
            return erros;
        }

        public static async Task<MoedaConvertida> ConverterMoedas(string MoedaOrigem, double ValorOrigem, string MoedaDestino)
        {
            Conversor conv = await ConversorController.CriaConversor(MoedaOrigem);
            double taxa = conv.getTaxa(MoedaDestino);
            double valorConvertido = ValorOrigem * taxa;
            return new MoedaConvertida(MoedaOrigem, ValorOrigem, MoedaDestino, valorConvertido, taxa);
        }
    }
}
