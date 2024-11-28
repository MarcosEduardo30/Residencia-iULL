using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologicaPersistencia.Entidades
{
    public class Consulta
    {
        public int Id { get; set; }
        public string CPFPaciente { get; set; }
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

        public Consulta(string CPFPaciente, DateOnly data, TimeOnly horaInicio, TimeOnly horaFim)
        {
            this.CPFPaciente = CPFPaciente;
            this.dataConsulta = data;
            this.horaInicio = horaInicio;
            this.horaFim = horaFim;
        }
    }
}
