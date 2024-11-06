using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    public static class Validacoes
    {
        public static bool isCPFCadastrado(this Consultorio consultorio, string CPF)
        {
            if (consultorio.pacientes.Exists(p => p.CPF == CPF)) return true;
            else return false;
        }

        public static bool existeConsultaFutura(this Consultorio consultorio, string CPF)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            bool existeconsulta = consultorio.consultas
                                  .Exists(c => c.CPFPaciente == CPF && ((c.dataConsulta > dataAtual) || (c.dataConsulta == dataAtual && c.horaInicio >= horaAtual)));
            if (existeconsulta)
                return true;
            else
                return false;
        }

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
    
    
    }
}
