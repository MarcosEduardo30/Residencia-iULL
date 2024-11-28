using ClinicaOdontologicaPersistencia.Entidades;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio.Validações;

namespace ClinicaOdontologicaPersistencia.Interface
{
    public static class PacienteInterface
    {
        public static void MenuPacientes(Consultorio consultorio)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1-Cadastrar novos pacientes");
                Console.WriteLine("2-Excluir Pacientes");
                Console.WriteLine("3-Listar Pacientes (ordenado por CPF)");
                Console.WriteLine("4-Listar Pacientes (ordenado por nome)");
                Console.WriteLine("5-Voltar p/ menu principal");
                string resp = Console.ReadLine();

                switch (resp)
                {
                    case "1":
                        CadastrarPaciente(consultorio);
                        break;
                    case "2":
                        ExcluirPaciente(consultorio);
                        break;
                    case "3":
                        ListarPacientes(consultorio, "CPF");
                        break;
                    case "4":
                        ListarPacientes(consultorio, "Nome");
                        break;
                    case "5":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Erro: Opção inválida. Por favor selecionar novamente");
                        break;
                }
            }
        }

        public static void CadastrarPaciente(Consultorio consultorio)
        {
            string CPF;
            string Nome;
            string Data;

            while (true)
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine().Trim();
                string CPFVal = PacienteValidacoes.isCpfValid(consultorio, CPF);
                if (CPFVal != "")
                {
                    Console.WriteLine(CPFVal);
                    continue;
                }
                else break;
            }

            while (true)
            {
                Console.Write("Nome: ");
                Nome = Console.ReadLine().Trim();
                string NomeVal = PacienteValidacoes.isNomeValid(Nome);
                if (NomeVal != "")
                {
                    Console.WriteLine(NomeVal);
                    continue;
                }
                else break;
            }

            while (true)
            {
                Console.Write("Data de Nascimento: ");
                Data = Console.ReadLine().Trim();
                string DataVal = PacienteValidacoes.isDataNascValid(Data);
                if (DataVal != "")
                {
                    Console.WriteLine(DataVal);
                    continue;
                }
                else break;
            }
            consultorio.incluirPaciente(CPF, Nome, DateTime.Parse(Data));
            Console.WriteLine("Paciente cadastrado com sucesso");
        }

        public static void ExcluirPaciente(Consultorio consultorio)
        {
            Console.Write("CPF: ");
            string CPFInput = Console.ReadLine();
            string CPFVal = PacienteValidacoes.isPacienteDeleteValid(consultorio, CPFInput);
            if (CPFVal != "")
                Console.WriteLine(CPFVal);
            else
            {
                consultorio.DeletarPaciente(CPFInput);
                Console.WriteLine("Paciente deletado com sucesso");
            }

        }

        public static void ListarPacientes(Consultorio consultorio, string ordem)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("CPF        \tNome                          \tDt.Nasc    \tIdade");
            Console.WriteLine("--------------------------------------------------------------------------");

            List<Paciente> pacientesOrdenados = consultorio.ListarPacientes(ordem);
            foreach (Paciente p in pacientesOrdenados)
            {
                Console.WriteLine($"{p.CPF}\t{p.Nome.PadRight(30)}\t{p.DataNascimento.ToString("dd/MM/yyyy")}\t{p.Idade}");
                if (consultorio.existeConsultaFutura(p.CPF))
                {
                    Consulta con = consultorio.ListarConsultasFuturas(p.CPF);
                    Console.WriteLine($"           \tAgendado para: {con.dataConsulta}");
                    Console.WriteLine($"           \t{con.horaInicio} às {con.horaFim}");
                }
            }

        }
    }
}
