using ConsultorioOdontologico.Entidades;
using ConsultorioOdontologico.LogicaDeNegocio;
using ConsultorioOdontologico.LogicaDeNegocio.Validações;

namespace ConsultorioOdontologico.Interface
{
    public static class ConsultaInterface
    {
        public static void MenuConsultas(Consultorio consultorio)
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
                        AgendarConsulta(consultorio);
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

        public static void AgendarConsulta(Consultorio consultorio)
        {
            string CPF;
            string Data;
            TimeOnly HoraInicio;
            TimeOnly HoraFim;

            while (true)
            {
                Console.Write("CPF: ");
                CPF = Console.ReadLine().Trim();
                string CPFVal = ConsultaValidacoes.validarCPF(consultorio, CPF);
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
                string InicioVal = ConsultaValidacoes.isHourFormatValid(InicioInput);
                if (InicioVal != "")
                {
                    Console.WriteLine(InicioVal);
                    continue;
                }
                else
                    HoraInicio = new TimeOnly(int.Parse(InicioInput.Substring(0, 2)), int.Parse(InicioInput.Substring(2)));

                Console.Write("Hora Final: ");
                string FimInput = Console.ReadLine().Trim();
                string FimVal = ConsultaValidacoes.isHourFormatValid(FimInput);
                if (FimVal != "")
                {
                    Console.WriteLine(FimVal);
                    continue;
                }
                else
                    HoraFim = new TimeOnly(int.Parse(FimInput.Substring(0, 2)), int.Parse(FimInput.Substring(2)));


                string HorarioVal = ConsultaValidacoes.validarHorario(consultorio, Data, HoraInicio, HoraFim);
                if (HorarioVal != "")
                {
                    Console.WriteLine(HorarioVal);
                    continue;
                }
                else
                    break;
            }
            
            consultorio.AgendarConsulta(CPF, Data, HoraInicio, HoraFim);
            Console.WriteLine("Consulta agendada com sucesso");

        }
    }
}
