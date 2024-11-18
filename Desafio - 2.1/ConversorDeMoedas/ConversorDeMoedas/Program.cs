using ConversorDeMoedas.Entidades;
using ConversorDeMoedas.Interfaces;
using ConversorDeMoedas.LogicaDeNegocio;
using System.Net;

namespace ConversorDeMoedas
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await ConversorView.ConverterValores();
        }
    }
}
