using MediatR;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;

namespace XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand
{
    /// <summary>
    /// Comando para crear un nuevo pedido.
    /// </summary>
    public class CreatePedidoCommand : IRequest<BaseResponse<bool>>
    {
        /// <summary>
        /// Obtiene o establece el identificador del usuario solicitante del pedido.
        /// </summary>
        public int? IdUsuarioSolicitante { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del repartidor asignado al pedido.
        /// </summary>
        public string? Repartidor { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de detalles del pedido.
        /// </summary>
        public virtual ICollection<DetallePedidoCommand> DetallePedido { get; set; }
    }

    /// <summary>
    /// Comando que representa un detalle específico de un pedido.
    /// </summary>
    public class DetallePedidoCommand
    {
        /// <summary>
        /// Obtiene o establece el identificador del producto asociado al detalle del pedido.
        /// </summary>
        public int? IdProducto { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad del producto en el detalle del pedido.
        /// </summary>
        public int? Cantidad { get; set; }

        /// <summary>
        /// Obtiene o establece el precio unitario del producto en el detalle del pedido.
        /// </summary>
        public decimal? Precio { get; set; }

        /// <summary>
        /// Obtiene o establece el total del detalle del pedido, calculado en base a la cantidad y el precio.
        /// </summary>
        public decimal? Total { get; set; }
    }
}
