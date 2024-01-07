namespace XYZBoutique.Application.Dtos
{
    public class PedidosWithFilterDto
    {
        public int IdPedido { get; set; }
        public string? NroPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? UsuarioSolicitante { get; set; }
        public string? Repartidor { get; set; }
        public int? IdEstadoPedido { get; set; }
        public string? EstadoPedido { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public IEnumerable<DetallePedidoDto> DetallePedido { get; set; }
    }

    public class DetallePedidoDto
    {
        public int IdDetallePedido { get; set; }
        public string? Producto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
