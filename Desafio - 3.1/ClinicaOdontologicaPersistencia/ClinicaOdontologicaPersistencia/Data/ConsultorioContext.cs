using ClinicaOdontologicaPersistencia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaPersistencia.Data
{
    public class ConsultorioContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
