using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologicaPersistencia.Entidades
{
    public class Consulta
    {
        public int Id { get; set; }
        public string CPFPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public DateOnly dataConsulta { get; set; }
        public TimeOnly horaInicio { get; set; }
        public TimeOnly horaFim { get; set; }

        [NotMapped]
        public TimeSpan TempoConsulta
        {
            get
            {
                return horaFim - horaInicio;
            }
        }
    }
}
