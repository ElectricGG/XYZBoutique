using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Infrastructure.Persistences.Context.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.HasKey(e => e.IdDetallePedido).HasName("PK__DetalleP__610F005664EFEDA4");

            builder.ToTable("DetallePedido");

            builder.Property(e => e.IdDetallePedido).HasColumnName("idDetallePedido");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            builder.Property(e => e.IdPedido).HasColumnName("idPedido");
            builder.Property(e => e.IdProducto).HasColumnName("idProducto");
            builder.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedido)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__DetallePe__idPed__4F7CD00D");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedido)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetallePe__idPro__5070F446");
        }
    }
}
