using ClinicaOdontologicaPersistencia.Entidades;

namespace ClinicaOdontologicaPersistencia.Interface
{
    public static class MenuPrincipal
    {
        public static void menuPrincipal()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Menu principal: ");
                Console.WriteLine("1-Cadastro de pacientes");
                Console.WriteLine("2-Agenda");
                Console.WriteLine("3-Fim");
                string resp = Console.ReadLine();

                switch (resp)
                {
                    case "1":
                        PacienteInterface.MenuPacientes();
                        break;
                    case "2":
                        ConsultaInterface.MenuConsultas();
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
