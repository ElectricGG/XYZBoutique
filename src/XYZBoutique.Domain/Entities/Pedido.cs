namespace XYZBoutique.Domain.Entities;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string? NroPedido { get; set; }

    public DateTime? FechaPedido { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public DateTime? FechaDespacho { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? IdUsuarioSolicitante { get; set; }

    public string? Repartidor { get; set; }

    public int? IdEstadoPedido { get; set; }

    public bool? Estado { get; set; }
    public DateTime? FechaRegistro{ get; set; }

    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    public virtual EstadoPedido? IdEstadoPedidoNavigation { get; set; }

    public virtual Usuario? IdUsuarioSolicitanteNavigation { get; set; }
}
