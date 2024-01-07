using MediatR;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;

namespace XYZBoutique.Application.UseCase.UseCases.Pedido.Commands.UpdateCommand
{
    /// <summary>
    /// Comando para actualizar el estado de un pedido por su identificador.
    /// </summary>
    public class UpdateEstadoPedidoByIdCommand : IRequest<BaseResponse<bool>>
    {
        /// <summary>
        /// Obtiene o establece el identificador único del pedido que se desea actualizar.
        /// </summary>
        public int IdPedido { get; set; }

        /// <summary>
        /// Obtiene o establece el nuevo identificador de estado que se asignará al pedido.
        /// </summary>
        public int? IdEstadoPedido { get; set; }
    }
}
