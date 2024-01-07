namespace XYZBoutique.Domain.Entities;

public partial class Correlativo
{
    public int IdCorrelativo { get; set; }

    public string? NumeroDoc { get; set; }

    public string? NombreTabla { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
