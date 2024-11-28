using ClinicaOdontologicaPersistencia.Data;
using ClinicaOdontologicaPersistencia.Entidades;

namespace ClinicaOdontologicaPersistencia.LogicaDeNegocio
{
    public class ConsultaController
    {
        ConsultorioContext dbContext;
        public ConsultaController()
        {
            dbContext = new ConsultorioContext();
        }
        public void AgendarConsulta(string CPF, string Data, TimeOnly HoraInicio, TimeOnly HoraFim)
        {
            //Consulta consulta = new Consulta(CPF, DateOnly.Parse(Data), HoraInicio, HoraFim);
            //con.consultas.Add(consulta);
        }

        public bool DeletarConsulta(string CPF, string Data, TimeOnly horaInicio)
        {
            //DateOnly dataConsu = DateOnly.Parse(Data);
            //int removidos = con.consultas.RemoveAll(c => c.CPFPaciente == CPF && c.dataConsulta == dataConsu && c.horaInicio == horaInicio);

            //if (removidos > 0)
            //    return true;
            //else
            //    return false;

            return true;
        }

        public bool DeletarConsulta(string CPF)
        {
            //int removidos = con.consultas.RemoveAll(c => c.CPFPaciente == CPF);

            //if (removidos > 0)
            //    return true;
            //else
            //    return false;

            return true;
        }

        public Consulta? ListarConsultasFuturas(string CPF)
        {
            //DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            //TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            //return con.consultas
            //    .Find(c => c.CPFPaciente == CPF && ((c.dataConsulta > dataAtual) || (c.dataConsulta == dataAtual && c.horaInicio >= horaAtual)));
            return new Consulta();
        }

        public List<Consulta> ListarConsultas()
        {
            //return con.consultas
            //    .OrderBy(c => c.dataConsulta)
            //    .ThenBy(c => c.horaInicio)
            //    .ToList();
            return new List<Consulta>();
        }

        public List<Consulta> ListarConsultas(DateOnly DataInicio, DateOnly DataFim)
        {
            //return con.consultas
            //    .FindAll(c => c.dataConsulta >= DataInicio && c.dataConsulta <= DataFim)
            //    .OrderBy(c => c.dataConsulta)
            //    .ThenBy(c => c.horaInicio)
            //    .ToList();
            return new List<Consulta>();
        }
    }
}
