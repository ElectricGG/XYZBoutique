namespace XYZBoutique.Domain.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Sku { get; set; }

    public int? IdTipo { get; set; }

    public string? Etiquetas { get; set; }

    public decimal? Precio { get; set; }

    public int? IdUnidadMedida { get; set; }
    public int? Stock { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    public virtual Tipo? IdTipoNavigation { get; set; }

    public virtual UnidadMedida? IdUnidadMedidaNavigation { get; set; }
}
