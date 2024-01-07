namespace XYZBoutique.Application.Dtos
{
    public class UsuariosByRolDto
    {
        public int IdUsuario { get; set; }

        public string? CodigoTrabajador { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Puesto { get; set; }

        public string? Rol { get; set; }

        public DateTime? FechaRegistro { get; set; }

    }
}
