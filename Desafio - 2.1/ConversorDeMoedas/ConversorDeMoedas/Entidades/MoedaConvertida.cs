using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorDeMoedas.Entidades
{
    public class MoedaConvertida
    {
        public string MoedaOrigem { get; set; }
        public double ValorOrigem { get; set; }
        public string MoedaDestino { get; set; }
        public double ValorDestino { get; set; }
        public double Taxa { get; set; }

        public MoedaConvertida(string MoedaOrigem, double ValorOrigem, string MoedaDestino, double ValorDestino, double Taxa)
        {
            this.MoedaOrigem = MoedaOrigem;
            this.ValorOrigem = ValorOrigem;
            this.MoedaDestino = MoedaDestino;
            this.ValorDestino = ValorDestino;
            this.Taxa = Taxa;
        }

    }
}
