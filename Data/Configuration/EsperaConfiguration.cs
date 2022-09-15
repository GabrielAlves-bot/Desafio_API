using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_API.Data.Configuration
{
    public class EsperaConfiguration : IEntityTypeConfiguration<Espera>
    {
        public void Configure(EntityTypeBuilder<Espera> builder)
        {
            builder.ToTable("tb_espera");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.TipoAtendimento).HasColumnName("tipo_atendimento");
            builder.Property(x => x.StatusPainel).HasColumnName("status_painel");
            builder.Property(x => x.DtEmissao).HasColumnName("data_emissao");
        }
    }
}
