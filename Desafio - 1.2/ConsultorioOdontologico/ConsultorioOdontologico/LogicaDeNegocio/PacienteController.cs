using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio
{
    public static class PacienteController
    {
        public static void incluirPaciente(this Consultorio con,string CPF, string Nome, DateTime DataNascimento)
        {
            Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            con.pacientes.Add(paciente);
        }
    }
}
