using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.Interface
{
    public static class MenuPrincipal
    {
        public static void menuPrincipal()
        {
            Consultorio consultorio = new Consultorio();

            bool loop = true;
            while (loop) {
                Console.WriteLine("Menu principal: ");
                Console.WriteLine("1-Cadastro de pacientes");
                Console.WriteLine("2-Agenda");
                Console.WriteLine("3-Fim");
                string resp = Console.ReadLine();

                switch (resp)
                {
                    case "1":
                        PacienteInterface.MenuPacientes(consultorio);
                        break;
                    case "2":
                        ConsultaInterface.MenuConsultas(consultorio);
                        break;
                    case "3":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione Novamente");
                        break;
                }
            }
        }
    }
}
