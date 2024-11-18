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
            var teste = await ConversorController.CriaConversor("USD");
            Console.WriteLine(teste.MoedaOrigem);
            Console.WriteLine(teste.Taxas.BRL);
            // ConversorView.ConverterValores();
        }
    }
}
