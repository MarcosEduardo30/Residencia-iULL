using ConsultorioOdontologico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    public static class ConsultaValidacoes
    {
        public static string isHourFormatValid(string hora)
        {
            if (hora == null || hora == "") 
                return "Erro: Hora não pode ser nula.";
            if (hora.Length != 4) 
                return "Erro: Hora está em um formato inválido. Por favor colocar a hora no formato HHMM";

            int horas;
            int minutos;

            if (!int.TryParse(hora.Substring(0, 2), out horas) || !int.TryParse(hora.Substring(2), out minutos))
                return "Erro: Por favor digite apenas valores numéricos na hora";
            if (horas < 08 || horas > 19)
                return "Erro: Horário inválido. As consultas devem ser agendadas entre 08:00 e as 19:00";
            if (minutos < 0 || minutos > 59)
                return "Erro: Valor de minutos errado.";
            if (minutos % 15 != 0)
                return "Erro: Horários devem ser escolhidos em intervalos de 15 em 15 minutos";
            return "";
        }

        public static bool isHoraOcupada(this Consultorio consultorio, TimeOnly horaInicial, TimeOnly horaFinal)
        {
            if (consultorio.consultas.Exists(c => c.temSobreposicao(horaInicial, horaFinal))) 
                return true;
            else 
                return false;
        }

        public static bool temSobreposicao(this Consulta consulta, TimeOnly inicio, TimeOnly fim)
        {
            if (consulta.horaInicio > inicio && consulta.horaInicio < fim) return true;
            else if (consulta.horaFim > inicio && consulta.horaFim < fim) return true;
            else if (inicio > consulta.horaInicio && inicio < consulta.horaFim) return true;
            else if (fim > consulta.horaInicio && fim < consulta.horaFim) return true;
            else return false;
        }
    }
}
