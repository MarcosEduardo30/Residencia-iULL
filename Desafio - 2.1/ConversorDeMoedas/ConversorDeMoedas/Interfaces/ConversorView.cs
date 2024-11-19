using ConversorDeMoedas.Entidades;
using ConversorDeMoedas.LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorDeMoedas.Interfaces
{
    public class ConversorView
    {
        public static async Task ConverterValores()
        {
            string origemInput;
            string destinoInput;
            ConversaoMoedas moedaConvertida;

            while (true) {
                Console.Write("Moeda Origem: ");
                origemInput = Console.ReadLine();
                if (origemInput == "")
                    break;

                Console.Write("Moeda Destino: ");
                destinoInput = Console.ReadLine();

                Console.Write("Valor: ");
                string valorInput = Console.ReadLine();


                List<string> erros = ConversaoMoedasController.ValidarInput(origemInput, valorInput, destinoInput);
                if (erros.Count != 0){
                    foreach (string e in erros)
                        Console.WriteLine(e);
                    continue;
                }

                try{
                    moedaConvertida = await ConversaoMoedasController.ConverterMoedas(origemInput, valorInput.Replace(",", "."), destinoInput);
                }
                catch (Exception e){
                    ApresentarErro(e.Message);
                    continue;
                }
                
                Console.WriteLine($"{moedaConvertida.MoedaOrigem} " +
                    $"{moedaConvertida.valorOrigem.ToString("0.00")} => " +
                    $"{moedaConvertida.MoedaDestino} " +
                    $"{moedaConvertida.ValorConversao.ToString("0.00")}");
                Console.WriteLine($"Taxa: {moedaConvertida.Taxa.ToString("0.000000")}");
            }
        }
        public static void ApresentarErro(string erro)
        {
            switch (erro)
            {
                case "unsupported-code":
                    Console.WriteLine("Erro: Sigla de moeda selecionada não é suportada pelo sistema!");
                    break;
                case "invalid-key": case "malformed-request": case "inactive-account": case "quota-reached":
                    Console.WriteLine("Erro interno do sistema! Por favor contacte o desenvolvedor");
                    break;
                default:
                    Console.WriteLine($"Erro de comunicação com o conversor de moedas! Contate o desenvolvedor com o código de erro {erro}");
                    break;
            }
        }
    }
}
