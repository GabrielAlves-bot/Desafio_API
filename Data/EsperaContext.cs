using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Data
{
    public class EsperaContext : DbContext
    {
        public EsperaContext(DbContextOptions<EsperaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Espera> Espera { get; set; }
    }
}
