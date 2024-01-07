namespace XYZBoutique.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? CodigoTrabajador { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Puesto { get; set; }

    public int? IdRol { get; set; }

    public string? Clave { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Pedido> PedidoIdUsuarioSolicitanteNavigations { get; set; } = new List<Pedido>();
}
