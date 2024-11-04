using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.Entidades
{
    public class Consulta
    {
        public string CPFPaciente;
        public DateOnly dataConsulta;
        public TimeOnly horaInicio;
        public TimeOnly horaFim;

        public Consulta(string CPFPaciente, DateTime data)
        {
                
        }

    }
}
