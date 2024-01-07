using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Infrastructure.Persistences.Context.Configurations
{
    public class CorrelativoConfiguration : IEntityTypeConfiguration<Correlativo>
    {
        public void Configure(EntityTypeBuilder<Correlativo> builder)
        {
            builder.HasKey(e => e.IdCorrelativo).HasName("PK__Correlat__B03821F34B4C2F7A");

            builder.ToTable("Correlativo");

            builder.Property(e => e.IdCorrelativo).HasColumnName("idCorrelativo");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            builder.Property(e => e.NombreTabla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTabla");
            builder.Property(e => e.NumeroDoc)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("numeroDoc");
        }
    }
}
