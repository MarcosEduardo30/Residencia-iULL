using ClinicaOdontologicaPersistencia.Entidades;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio.Validações;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicaOdontologicaPersistencia.Interface
{
    public static class ConsultaInterface
    {
        static readonly ConsultaController ConsulCon = new ConsultaController();
        static readonly PacienteController PacCon = new PacienteController();
        public static void MenuConsultas()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Agenda");
                Console.WriteLine("1-Agendar Consulta");
                Console.WriteLine("2-Cancelar agendamento");
                Console.WriteLine("3-Listar agenda");
                Console.WriteLine("4-Voltar p/ menu principal");
                string resp = Console.ReadLine();

                switch (resp)
                {
                    case "1":
                        AgendarConsulta();
                        break;
                    case "2":
                        CancelarConsulta();
                        break;
                    case "3":
                        listarConsultas();
                        break;
                    case "4":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Erro: Opção inválida. Por favor selecionar novamente");
                        break;
                }
            }
        }

        public static void AgendarConsulta()
        {
            string CPF;
            string Data;
            TimeOnly HoraInicio;
            TimeOnly HoraFim;

            while (true)
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine().Trim();
                string CPFVal = ConsultaValidacoes.isCpfValid(CPF);
                if (CPFVal != "")
                {
                    Console.WriteLine(CPFVal);
                    return;
                }
                else break;
            }

            while (true)
            {
                Console.Write("Data da Consulta: ");
                Data = Console.ReadLine().Trim();
                string DataVal = Validacoes.isDataFormatValid(Data);
                if (DataVal != "")
                {
                    Console.WriteLine(DataVal);
                    continue;
                }

                Console.Write("Hora Inicial: ");
                string InicioInput = Console.ReadLine().Trim();
                string InicioVal = Validacoes.isHourFormatValid(InicioInput);
                if (InicioVal != "")
                {
                    Console.WriteLine(InicioVal);
                    continue;
                }
                else
                    HoraInicio = new TimeOnly(int.Parse(InicioInput.Substring(0, 2)), int.Parse(InicioInput.Substring(2)));

                Console.Write("Hora Final: ");
                string FimInput = Console.ReadLine().Trim();
                string FimVal = Validacoes.isHourFormatValid(FimInput);
                if (FimVal != "")
                {
                    Console.WriteLine(FimVal);
                    continue;
                }
                else
                    HoraFim = new TimeOnly(int.Parse(FimInput.Substring(0, 2)), int.Parse(FimInput.Substring(2)));


                string HorarioVal = ConsultaValidacoes.isHorarioValid(Data, HoraInicio, HoraFim);
                if (HorarioVal != "")
                {
                    Console.WriteLine(HorarioVal);
                    continue;
                }
                else
                    break;
            }

            ConsulCon.AgendarConsulta(CPF, Data, HoraInicio, HoraFim);
            Console.WriteLine("Consulta agendada com sucesso");

        }

        public static void CancelarConsulta()
        {
            TimeOnly horaInicio;
            string DataInput;
            ;

            Console.Write("CPF: ");
            string CPFInput = Console.ReadLine();
            if (PacienteValidacoes.isCPFCadastrado(CPFInput))
            {
                Console.WriteLine("Erro: Paciente não cadastrado");
                return;
            }

            while (true)
            {
                Console.Write("Data da consulta: ");
                DataInput = Console.ReadLine();
                string DataVal = Validacoes.isDataFormatValid(DataInput);
                if (DataVal != "")
                {
                    Console.WriteLine(DataVal);
                    continue;
                }

                Console.Write("Hora de inicio: ");
                string HoraInput = Console.ReadLine();
                string InicioVal = Validacoes.isHourFormatValid(HoraInput);
                if (InicioVal != "")
                {
                    Console.WriteLine(InicioVal);
                    continue;
                }
                else
                    horaInicio = new TimeOnly(int.Parse(HoraInput.Substring(0, 2)), int.Parse(HoraInput.Substring(2)));

                if (!ConsultaValidacoes.isDataFutura(DateOnly.Parse(DataInput), horaInicio))
                {
                    Console.WriteLine("Erro: Não é possivel cancelar consultas passadas");
                    continue;
                }
                else
                    break;
            }

            if (ConsulCon.DeletarConsulta(CPFInput, DataInput, horaInicio))
            {
                Console.WriteLine("Consulta deletada com sucesso");
            }
            else
            {
                Console.WriteLine("Erro: agendamento não encontrado");
            }

        }

        public static void listarConsultas()
        {
            string modo;
            while (true)
            {
                Console.Write("Apresentar a agenda T-Toda ou P-Periodo: ");
                string res = Console.ReadLine();
                if (res == "T" || res == "P")
                {
                    modo = res;
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Favor selecionar novamente");
                }
            }

            List<Consulta> consultas;

            if (modo == "P")
            {
                DateOnly dataInicial;
                DateOnly dataFinal;
                while (true)
                {
                    Console.Write("Data inicial: ");
                    string dtInicialInput = Console.ReadLine();
                    string dtValid = Validacoes.isDataFormatValid(dtInicialInput);

                    Console.Write("Data final: ");
                    string dtFinalInput = Console.ReadLine();
                    dtValid = Validacoes.isDataFormatValid(dtFinalInput);

                    if (dtValid != "")
                    {
                        Console.WriteLine(dtValid);
                        continue;
                    }
                    else
                    {
                        dataInicial = DateOnly.Parse(dtInicialInput);
                        dataFinal = DateOnly.Parse(dtFinalInput);
                        break;
                    }
                }
                consultas = ConsulCon.ListarConsultas(dataInicial, dataFinal);
            }
            else
            {
                consultas = ConsulCon.ListarConsultas();
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  Data  \tH.Ini\tH.Fim\tTempo\tNome                          \tDt.Nasc.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            foreach (Consulta cons in consultas)
            {
                Paciente pac = PacCon.ListarPaciente(cons.CPFPaciente);
                Console.WriteLine($"{cons.dataConsulta}" +
                    $"\t{cons.horaInicio}" +
                    $"\t{cons.horaFim}" +
                    $"\t{cons.TempoConsulta.ToString("hh\\:mm")}" +
                    $"\t{pac.Nome.PadRight(30)}" +
                    $"\t{pac.DataNascimento.ToString("dd/MM/yyyy")}");
            }

        }
    }
}
