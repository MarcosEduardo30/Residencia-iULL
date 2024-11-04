using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio
{
    public static class PacienteController
    {
        public static void incluirPaciente(this Consultorio consultorio,string CPF, string Nome, DateTime DataNascimento)
        {
            Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            consultorio.pacientes.Add(paciente);
        }
    }
}
