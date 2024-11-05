using ConsultorioOdontologico.Interface;
namespace ConsultorioOdontologico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string teste = "0815";
            Console.WriteLine(teste.Substring(0, 2));
            Console.WriteLine(teste.Substring(2));
            MenuPrincipal.menuPrincipal();
        }
    }
}
