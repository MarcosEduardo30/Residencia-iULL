using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.Entidades
{
    public class Consultorio
    {
        public List<Paciente> pacientes;
        public List<Consulta> consultas;

        public Consultorio()
        {
            this.pacientes = [];
            this.consultas = [];
        }
    }
}
