using ClinicaOdontologicaPersistencia.Data;
using ClinicaOdontologicaPersistencia.Entidades;
using ClinicaOdontologicaPersistencia.Interface;
using ClinicaOdontologicaPersistencia.LogicaDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaPersistencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Con = new PacienteController();
            var paciente = new Paciente("51025807873", "Marquinhos 3", new DateTime(2002, 07, 30));
            Con.incluirPaciente("51025807874", "Marquinhos 4", new DateTime(2002, 07, 30));

            foreach (var p in Con.ListarPacientes("CPF"))
            {
                Console.WriteLine($"Nome: {p.Nome} | Idade: {p.Idade} | CPF: {p.CPF}");
                Console.WriteLine();
            }



            //MenuPrincipal.menuPrincipal();
        }
    }
}
