using ClinicaOdontologicaPersistencia.Entidades;

namespace ClinicaOdontologicaPersistencia.LogicaDeNegocio.Validações
{
    public static class Validacoes
    {
        //Classe estática com validações genéricas utilizadas por ambas as interfaces de Paciente e de Consulta.
        public static string isDataFormatValid(string data)
        {
            string[] subData = data.Split('/');
            if (subData.Length != 3) 
                return "Erro: Data formatada errada! Por favor colocar a data no formato DD/MM/AAAA";
            if (subData[0].Length != 2 || subData[1].Length != 2 || subData[2].Length != 4)
                return "Erro: Data formatada errada! Por favor colocar a data no formato DD/MM/AAAA";
            int dia;
            int mes;
            int ano;

            if (!int.TryParse(subData[0], out dia) || !int.TryParse(subData[1], out mes) || !int.TryParse(subData[2], out ano))
                return "Erro: Data possui um valor não númerico";

            if (mes > 12 || mes < 1) return "Erro: Mes inválido";

            switch (mes)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    if (dia > 31 || dia < 1) return "Erro: Dia Inválido";
                    break;
                case 4: case 9: case 11:
                    if (dia > 30 || dia < 1) return "Erro: Dia Inválido";
                    break;
                case 2:
                    if (ano % 4 == 0){
                        if (dia > 29 || dia < 1) return "Erro: Dia Inválido";
                    }
                    else{
                        if (dia > 28 || dia < 1) return "Erro: Dia Inválido";
                    }
                    break;
            }
            if (ano < 1) 
                return "Erro: Ano Inválido!";
            else 
                return "";
        }

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
            if ((horas < 08 || horas > 19) || (horas == 19 && minutos > 0))
                return "Erro: Horário inválido. As consultas devem ser agendadas entre 08:00 e as 19:00";
            if (minutos < 0 || minutos > 59)
                return "Erro: Valor de minutos errado.";
            if (minutos % 15 != 0)
                return "Erro: Horários devem ser escolhidos em intervalos de 15 em 15 minutos";
            return "";
        }
    }
}
