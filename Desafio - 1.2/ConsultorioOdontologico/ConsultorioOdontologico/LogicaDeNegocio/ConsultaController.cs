using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio
{
    public static class ConsultaController
    {
        public static void AgendarConsulta(this Consultorio con, string CPF, string Data, TimeOnly HoraInicio, TimeOnly HoraFim)
        {
            Consulta consulta = new Consulta(CPF, DateOnly.Parse(Data), HoraInicio, HoraFim);
            con.consultas.Add(consulta);
        }

        public static bool DeletarConsulta(this Consultorio con, string CPF, string Data, TimeOnly horaInicio)
        {
            DateOnly dataConsu = DateOnly.Parse(Data);
            int removidos = con.consultas.RemoveAll(c => c.CPFPaciente == CPF && c.dataConsulta == dataConsu && c.horaInicio == horaInicio);

            if (removidos > 0)
                return true;
            else
                return false;
        }

        public static bool DeletarConsulta(this Consultorio con, string CPF)
        {
            int removidos = con.consultas.RemoveAll(c => c.CPFPaciente == CPF);

            if (removidos > 0)
                return true;
            else
                return false;
        }

        public static Consulta? ListarConsultasFuturas(this Consultorio con, string CPF)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            return con.consultas
                .Find(c => c.CPFPaciente == CPF && ((c.dataConsulta > dataAtual) || (c.dataConsulta == dataAtual && c.horaInicio >= horaAtual)));
        }


    }
}
