using ClinicaOdontologicaPersistencia.Entidades;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio.Validações;

namespace ClinicaOdontologicaPersistencia.Interface
{
    public static class PacienteInterface
    {
        static readonly PacienteController PacCon = new PacienteController();
        static readonly ConsultaController ConsulCon = new ConsultaController();
        public static void MenuPacientes()
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
                        CadastrarPaciente();
                        break;
                    case "2":
                        ExcluirPaciente();
                        break;
                    case "3":
                        ListarPacientes("CPF");
                        break;
                    case "4":
                        ListarPacientes("Nome");
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

        public static void CadastrarPaciente()
        {
            string CPF;
            string Nome;
            string Data;

            while (true)
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine().Trim();
                string CPFVal = PacienteValidacoes.isCpfValid(CPF);
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

            PacCon.incluirPaciente(CPF, Nome, DateTime.Parse(Data));
            Console.WriteLine("Paciente cadastrado com sucesso");
        }

        public static void ExcluirPaciente()
        {
            Console.Write("CPF: ");
            string CPFInput = Console.ReadLine();
            string CPFVal = PacienteValidacoes.isPacienteDeleteValid(CPFInput);
            if (CPFVal != "")
                Console.WriteLine(CPFVal);
            else
            {
                PacCon.DeletarPaciente(CPFInput);
                Console.WriteLine("Paciente deletado com sucesso");
            }

        }

        public static void ListarPacientes(string ordem)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("CPF        \tNome                          \tDt.Nasc    \tIdade");
            Console.WriteLine("--------------------------------------------------------------------------");

            List<Paciente> pacientesOrdenados = PacCon.ListarPacientes(ordem);
            foreach (Paciente p in pacientesOrdenados)
            {
                Console.WriteLine($"{p.CPF}\t{p.Nome.PadRight(30)}\t{p.DataNascimento.ToString("dd/MM/yyyy")}\t{p.Idade}");
                if (ConsultaValidacoes.existeConsultaFutura(p.CPF))
                {
                    Consulta con = ConsulCon.ListarConsultasFuturas(p.CPF);
                    Console.WriteLine($"           \tAgendado para: {con.dataConsulta}");
                    Console.WriteLine($"           \t{con.horaInicio} às {con.horaFim}");
                }
            }

        }
    }
}
