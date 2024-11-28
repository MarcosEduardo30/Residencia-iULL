using ClinicaOdontologicaPersistencia.Data;
using ClinicaOdontologicaPersistencia.Entidades;

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
            //Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            //con.pacientes.Add(paciente);
        }

        public void DeletarPaciente(string CPF)
        {
            //con.pacientes.RemoveAll(p => p.CPF == CPF);
            //con.DeletarConsulta(CPF);
        }

        public List<Paciente> ListarPacientes(string ordem)
        {
            //if (ordem == "CPF")
            //{
            //    return con.pacientes.OrderBy(p => p.CPF).ToList();
            //}
            //else
            //{
            //    return con.pacientes.OrderBy(p => p.Nome).ToList();
            //}
            List < Paciente > placeholder = new List < Paciente > ();
            return placeholder;

        }

        public Paciente? ListarPaciente(string CPF)
        {
            //return con.pacientes.Find(p => p.CPF == CPF);
            return new Paciente();
        }
    }
}
