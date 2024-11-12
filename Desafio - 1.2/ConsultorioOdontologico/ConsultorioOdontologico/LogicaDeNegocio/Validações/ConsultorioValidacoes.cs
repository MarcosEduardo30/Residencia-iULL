using ConsultorioOdontologico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    // Classe estática com as validações referentes a classe Consultorio.
    public static class ConsultorioValidacoes
    {
        public static bool isCPFCadastrado(this Consultorio consultorio, string CPF)
        {
            if (consultorio.pacientes.Exists(p => p.CPF == CPF)) return true;
            else return false;
        }

        public static bool existeConsultaFutura(this Consultorio consultorio, string CPF)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            bool existeConsulta = consultorio.consultas
                .Exists(c => c.CPFPaciente == CPF && ((c.dataConsulta > dataAtual) || (c.dataConsulta == dataAtual && c.horaInicio >= horaAtual)));
            if (existeConsulta)
                return true;
            else
                return false;
        }

        public static bool isHoraOcupada(this Consultorio consultorio, DateOnly dataConsulta, TimeOnly horaInicial, TimeOnly horaFinal)
        {
            if (consultorio.consultas.Exists(c => c.dataConsulta == dataConsulta && c.temSobreposicaoHorario(horaInicial, horaFinal)))
                return true;
            else
                return false;
        }
    }
}
