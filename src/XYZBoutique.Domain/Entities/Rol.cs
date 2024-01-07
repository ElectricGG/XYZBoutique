namespace XYZBoutique.Domain.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
