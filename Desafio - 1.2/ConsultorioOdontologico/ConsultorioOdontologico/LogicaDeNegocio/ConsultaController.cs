using ConsultorioOdontologico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.LogicaDeNegocio
{
    public static class ConsultaController
    {
        public static void AgendarConsulta(this Consultorio con, string CPF, string Data, TimeOnly HoraInicio, TimeOnly HoraFim)
        {
            Consulta consulta = new Consulta(CPF, DateOnly.Parse(Data), HoraInicio, HoraFim);
            con.consultas.Add(consulta);
        }

        public static void DeletarConsulta(this Consultorio con, string CPF, string Data, TimeOnly HoraInicio)
        {
            return;
        }

        public static void DeletarConsulta(this Consultorio con, string CPF)
        {
            con.consultas.RemoveAll(c => c.CPFPaciente == CPF);
        }
    }
}
