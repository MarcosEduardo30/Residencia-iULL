using ClinicaOdontologicaPersistencia.Data;
using ClinicaOdontologicaPersistencia.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaPersistencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<ConsultorioContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=consultorio;User Id=postgres;Password=batata123;")
                .Options;
            var dbContext = new ConsultorioContext();
            //dbContext.Database.EnsureCreated();
            //foreach(var p in dbContext.Pacientes)
            //{
            //    Console.WriteLine(p.Nome);
            //}
            //MenuPrincipal.menuPrincipal();
        }
    }
}
