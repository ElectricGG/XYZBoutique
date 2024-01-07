namespace XYZBoutique.Domain.Entities;

public partial class UnidadMedida
{
    public int IdUnidadMedida { get; set; }

    public string? Nombre { get; set; }

    public string? Abreviatura { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
