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
                    case "3":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione Novamente");
                        break;
                }
            }

            foreach (Paciente p in consultorio.pacientes)
            {
                Console.WriteLine($"CPF: {p.CPF} || Nome: {p.Nome}");
            }

            foreach(Consulta c in consultorio.consultas)
            {
                Console.WriteLine($"CPF Paciente: {c.CPFPaciente} || DataConsulta: {c.dataConsulta}");
            }
            
        }
    }
}
