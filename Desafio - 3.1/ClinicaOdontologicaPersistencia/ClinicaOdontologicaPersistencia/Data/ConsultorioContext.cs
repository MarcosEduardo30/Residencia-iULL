using ClinicaOdontologicaPersistencia.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClinicaOdontologicaPersistencia.Data
{
    public class ConsultorioContext: DbContext
    {
        //Propriedade que acessa um arquivo json com os dados de configuração do projeto.
        //Usado para acessar a string de conexão do banco de dados e manter ela secreta
        IConfigurationRoot configuracoes;
        public ConsultorioContext()
        {
            configuracoes = config.CriaConfig();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuracoes.GetConnectionString("postgresql"));
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
