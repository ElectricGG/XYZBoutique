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
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.IdPedido).HasName("PK__Pedido__A9F619B70974B5C0");

            builder.ToTable("Pedido");

            builder.Property(e => e.IdPedido).HasColumnName("idPedido");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");

            builder.Property(e => e.IdEstadoPedido)
                .HasDefaultValueSql("((1))")
                .HasColumnName("idEstadoPedido");

            builder.Property(e => e.FechaDespacho)
                .HasColumnType("datetime")
                .HasColumnName("fechaDespacho");
            builder.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fechaEntrega");
            builder.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaPedido");
            builder.Property(e => e.FechaRecepcion)
                .HasColumnType("datetime")
                .HasColumnName("fechaRecepcion");

            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");


            builder.Property(e => e.IdUsuarioSolicitante).HasColumnName("idUsuarioSolicitante");
            builder.Property(e => e.NroPedido)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("nroPedido");

            builder.Property(e => e.Repartidor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("repartidor");

            builder.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstadoPedido)
                .HasConstraintName("FK__Pedido__idEstado__44FF419A");


            builder.HasOne(d => d.IdUsuarioSolicitanteNavigation).WithMany(p => p.PedidoIdUsuarioSolicitanteNavigations)
                .HasForeignKey(d => d.IdUsuarioSolicitante)
                .HasConstraintName("FK__Pedido__idUsuari__4316F928");
        }
    }
}
