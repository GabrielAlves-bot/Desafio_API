using Desafio_API.Data.Configuration;
using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Espera> Espera { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EsperaConfiguration());
            modelBuilder.ApplyConfiguration(new AtendimentoConfiguration());
        }
    }
}
