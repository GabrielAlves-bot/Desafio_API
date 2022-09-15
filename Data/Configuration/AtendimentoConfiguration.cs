using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_API.Data.Configuration
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("tb_atendimento");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Mesa).HasColumnName("mesa");
            builder.Property(x => x.DtAtendimento).HasColumnName("data_atendimento");
        }
    }
}
