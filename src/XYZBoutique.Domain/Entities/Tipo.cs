namespace XYZBoutique.Domain.Entities;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
