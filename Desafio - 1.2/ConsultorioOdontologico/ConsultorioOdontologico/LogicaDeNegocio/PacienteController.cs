﻿using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio
{
    public static class PacienteController
    {
        public static void incluirPaciente(this Consultorio con,string CPF, string Nome, DateTime DataNascimento)
        {
            Paciente paciente = new Paciente(CPF, Nome, DataNascimento);
            con.pacientes.Add(paciente);
        }

        public static void DeletarPaciente(this Consultorio con, string CPF)
        {
            con.pacientes.RemoveAll(p => p.CPF == CPF);
            con.DeletarConsulta(CPF);
        }
    }
}
