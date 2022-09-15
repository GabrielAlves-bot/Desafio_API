using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Data
{
    public class AtendimentoContext : DbContext
    {
        public AtendimentoContext(DbContextOptions<AtendimentoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Atendimento> Atendimento { get; set; }

    }
}
