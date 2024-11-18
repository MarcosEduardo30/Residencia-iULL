using ConversorDeMoedas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorDeMoedas.LogicaDeNegocio
{
    public static class ConversaoMoedasController
    {
        public static List<string> ValidarConversaoMoedas(string MoedaOrigem, float ValorOrigem, string MoedaDestino)
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

        public static void ConverterMoedas()
        {

        }
    }
}
