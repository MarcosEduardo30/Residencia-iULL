using ClinicaOdontologicaPersistencia.Data;
using ClinicaOdontologicaPersistencia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaPersistencia.LogicaDeNegocio
{
    public class PacienteController
    {
        ConsultorioContext dbContext;

        public PacienteController()
        {
            dbContext = new ConsultorioContext();
        }

        public void incluirPaciente(string CPF, string Nome, DateTime DataNascimento)
        {
            Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            dbContext.Add(paciente);
            dbContext.SaveChanges();
        }

        public void DeletarPaciente(string CPF)
        {
            Paciente? pacToBeDeleted = dbContext.Pacientes.FirstOrDefault(p => p.CPF == CPF);
            dbContext.Pacientes.Remove(pacToBeDeleted);
            dbContext.SaveChanges();
        }

        public List<Paciente> ListarPacientes(string ordem)
        {
            if (ordem == "CPF")
            {
                return dbContext.Pacientes.OrderBy(p => p.CPF).ToList();
            }
            else
            {
                return dbContext.Pacientes.OrderBy(p => p.Nome).ToList();
            }

        }

        public Paciente? ListarPaciente(string CPF)
        {
            return dbContext.Pacientes.FirstOrDefault(p => p.CPF == CPF);
        }
    }
}
