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
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A1324160B3CA");

            builder.ToTable("Producto");

            builder.Property(e => e.IdProducto).HasColumnName("idProducto");

            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");

            builder.Property(e => e.Etiquetas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("etiquetas");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            builder.Property(e => e.IdTipo).HasColumnName("idTipo");
            builder.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");

            builder.Property(e => e.Stock)
                .HasColumnType("int")
                .HasColumnName("stock");

            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            builder.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sku");

            builder.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Producto__idTipo__48CFD27E");

            builder.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdUnidadMedida)
                .HasConstraintName("FK__Producto__idUnid__49C3F6B7");
        }
    }
}
