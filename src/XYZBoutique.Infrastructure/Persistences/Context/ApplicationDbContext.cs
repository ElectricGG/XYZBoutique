using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Infrastructure.Persistences.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Correlativo> Correlativos { get; set; }

        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }

        public virtual DbSet<Pedido> Pedidos { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Rol> Rols { get; set; }

        public virtual DbSet<Tipo> Tipos { get; set; }

        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}