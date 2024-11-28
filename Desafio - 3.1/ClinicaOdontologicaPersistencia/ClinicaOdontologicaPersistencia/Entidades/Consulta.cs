﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologicaPersistencia.Entidades
{
    public class Consulta
    {
        public string CPFPaciente;
        public DateOnly dataConsulta;
        public TimeOnly horaInicio;
        public TimeOnly horaFim;

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
