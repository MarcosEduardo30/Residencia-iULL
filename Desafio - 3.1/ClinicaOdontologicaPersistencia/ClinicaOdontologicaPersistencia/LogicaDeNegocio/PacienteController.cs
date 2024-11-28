using ClinicaOdontologicaPersistencia.Entidades;

namespace ClinicaOdontologicaPersistencia.LogicaDeNegocio
{
    public static class PacienteController
    {
        public static void incluirPaciente(this Consultorio con, string CPF, string Nome, DateTime DataNascimento)
        {
            Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            con.pacientes.Add(paciente);
        }

        public static void DeletarPaciente(this Consultorio con, string CPF)
        {
            con.pacientes.RemoveAll(p => p.CPF == CPF);
            con.DeletarConsulta(CPF);
        }

        public static List<Paciente> ListarPacientes(this Consultorio con, string ordem)
        {
            if (ordem == "CPF")
            {
                return con.pacientes.OrderBy(p => p.CPF).ToList();
            }
            else
            {
                return con.pacientes.OrderBy(p => p.Nome).ToList();
            }

        }

        public static Paciente? ListarPaciente(this Consultorio con, string CPF)
        {
            return con.pacientes.Find(p => p.CPF == CPF);
        }
    }
}
