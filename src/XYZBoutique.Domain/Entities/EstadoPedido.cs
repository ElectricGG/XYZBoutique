namespace XYZBoutique.Domain.Entities;

public partial class EstadoPedido
{
    public int IdEstadoPedido { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
