using ClinicaOdontologicaPersistencia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaPersistencia.Data
{
    public class ConsultorioContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Consultas)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.CPFPaciente)
                .IsRequired();
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
