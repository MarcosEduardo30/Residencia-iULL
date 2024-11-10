﻿using ConsultorioOdontologico.Entidades;
using ConsultorioOdontologico.LogicaDeNegocio;
using ConsultorioOdontologico.LogicaDeNegocio.Validações;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    case "2":
                        CancelarConsulta(consultorio);
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
    
        public static void CancelarConsulta(Consultorio consultorio)
        {
            TimeOnly horaInicio;
            string DataInput;
            ;

            Console.Write("CPF: ");
            string CPFInput = Console.ReadLine();
            if (!consultorio.isCPFCadastrado(CPFInput)){
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
                string InicioVal = ConsultaValidacoes.isHourFormatValid(HoraInput);
                if (InicioVal != "")
                {
                    Console.WriteLine(InicioVal);
                    continue;
                }
                else
                    horaInicio = new TimeOnly(int.Parse(HoraInput.Substring(0, 2)), int.Parse(HoraInput.Substring(2)));

                if (!ConsultaValidacoes.isConsultaFutura(DateOnly.Parse(DataInput), horaInicio))
                {
                    Console.WriteLine("Erro: Não é possivel cancelar consultas passadas");
                    continue;
                }
                else
                    break;
            }

            if (consultorio.DeletarConsulta(CPFInput, DataInput, horaInicio))
            {
                Console.WriteLine("Consulta deletada com sucesso");
            }
            else
            {
                Console.WriteLine("Erro: agendamento não encontrado");
            }

        }
    }
}
