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
        public static void ConverterValores()
        {
            string origemInput;
            string destinoInput;
            float valorOrigem;

            while (true) {
                Console.Write("Moeda Origem: ");
                origemInput = Console.ReadLine();
                if (origemInput == "")
                    break;

                Console.Write("Moeda Destino: ");
                destinoInput = Console.ReadLine();

                while (true) {
                    Console.Write("Valor: ");
                    string valorInput = Console.ReadLine();

                    if (!float.TryParse(valorInput, out valorOrigem))
                        Console.WriteLine("Favor digitar apenas valores numéricos");
                    else
                        break;
                }

                List<string> erros = ConversaoMoedasController.ValidarConversaoMoedas(origemInput, valorOrigem, destinoInput);
                if (erros.Count != 0)
                {
                    foreach (string e in erros)
                        Console.WriteLine(e);
                    continue;
                }


            }


        }
    }
}
