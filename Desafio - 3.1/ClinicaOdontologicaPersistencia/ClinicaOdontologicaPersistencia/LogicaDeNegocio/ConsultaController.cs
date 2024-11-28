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

            Consulta consulta = new Consulta
            {
                CPFPaciente = CPF,
                dataConsulta = DateOnly.Parse(Data),
                horaInicio = HoraInicio,
                horaFim = HoraFim
            };
            dbContext.Consultas.Add(consulta);
            dbContext.SaveChanges();
        }

        public bool DeletarConsulta(string CPF, string Data, TimeOnly horaInicio)
        {
            DateOnly dataConsu = DateOnly.Parse(Data);

            List<Consulta> toBeRemoved = dbContext.Consultas
                .Where(c => c.CPFPaciente == CPF && c.dataConsulta == dataConsu && c.horaInicio == horaInicio)
                .ToList();
            int removidos = toBeRemoved.Count();

            dbContext.Consultas.RemoveRange(toBeRemoved);
            dbContext.SaveChanges();

            if (removidos > 0)
                return true;
            else
                return false;
        }

        public bool DeletarConsulta(string CPF)
        {
            List<Consulta> toBeRemoved = dbContext.Consultas
                .Where(c => c.CPFPaciente == CPF)
                .ToList();
            int removidos = toBeRemoved.Count();

            dbContext.Consultas.RemoveRange(toBeRemoved);
            dbContext.SaveChanges();

            if (removidos > 0)
                return true;
            else
                return false;
        }

        public Consulta? ListarConsultasFuturas(string CPF)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            return dbContext.Consultas
                .FirstOrDefault(c => c.CPFPaciente == CPF 
                                && ((c.dataConsulta > dataAtual) || (c.dataConsulta == dataAtual && c.horaInicio >= horaAtual)));

        }

        public List<Consulta> ListarConsultas()
        {
            return dbContext.Consultas
                .OrderBy(c => c.dataConsulta)
                .ThenBy(c => c.horaInicio)
                .ToList();
        }

        public List<Consulta> ListarConsultas(DateOnly DataInicio, DateOnly DataFim)
        {
            return dbContext.Consultas
                .Where(c => c.dataConsulta >= DataInicio && c.dataConsulta <= DataFim)
                .OrderBy(c => c.dataConsulta)
                .ThenBy(c => c.horaInicio)
                .ToList();
        }
    }
}
