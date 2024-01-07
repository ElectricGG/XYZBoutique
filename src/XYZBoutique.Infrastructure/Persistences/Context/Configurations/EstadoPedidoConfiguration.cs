using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Infrastructure.Persistences.Context.Configurations
{
    public class EstadoPedidoConfiguration : IEntityTypeConfiguration<EstadoPedido>
    {
        public void Configure(EntityTypeBuilder<EstadoPedido> builder)
        {
            builder.HasKey(e => e.IdEstadoPedido).HasName("PK__EstadoPe__E0BFAD0FD2C552B3");

            builder.ToTable("EstadoPedido");

            builder.Property(e => e.IdEstadoPedido).HasColumnName("idEstadoPedido");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            builder.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        }
    }
}
