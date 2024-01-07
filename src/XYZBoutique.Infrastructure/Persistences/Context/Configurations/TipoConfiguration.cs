using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Infrastructure.Persistences.Context.Configurations
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(e => e.IdTipo).HasName("PK__Tipo__BDD0DFE121361AF7");

            builder.ToTable("Tipo");

            builder.Property(e => e.IdTipo).HasColumnName("idTipo");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        }
    }
}
