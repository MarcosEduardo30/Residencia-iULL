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
                bool CPFVal = consultorio.isCPFCadastrado(CPF);
                if (!CPFVal)
                {
                    Console.WriteLine("Erro: Paciente não cadastrado");
                    continue;
                }
                else break;
            }

            while (true) {
                Console.Write("Data da Consulta: ");
                Data = Console.ReadLine().Trim();
                string DataVal = Validacoes.isDataFormatValid(Data);
                if (DataVal != "")
                {
                    Console.WriteLine(DataVal);
                    continue;
                }
                else break;
            }

            while (true)
            {
                Console.Write("Hora Inicial: ");
                string InicioInput = Console.ReadLine().Trim();
                string HoraVal = ConsultaValidacoes.isHourFormatValid(InicioInput);
                if (HoraVal != "")
                {
                    Console.WriteLine(HoraVal);
                    continue;
                }
                else{
                    HoraInicio = new TimeOnly(int.Parse(InicioInput.Substring(0, 2)), int.Parse(InicioInput.Substring(2)));
                    break;
                }
            }

            while (true)
            {
                Console.Write("Hora Final: ");
                string FimInput = Console.ReadLine().Trim();
                string HoraVal = ConsultaValidacoes.isHourFormatValid(FimInput);
                if (HoraVal != "")
                {
                    Console.WriteLine(HoraVal);
                    continue;
                }
                else{
                    HoraFim = new TimeOnly(int.Parse(FimInput.Substring(0, 2)), int.Parse(FimInput.Substring(2)));
                    break;
                } 
                    
                    
            }

            if (consultorio.isHoraOcupada(HoraInicio, HoraFim))
            {
                Console.WriteLine("Erro: Hora já está ocupada. Favor selecionar outra data.");
            }
            else
            {
                consultorio.AgendarConsulta(CPF, Data, HoraInicio, HoraFim);
                Console.WriteLine("Consulta agendada com sucesso");
            }

        }
    }
}
