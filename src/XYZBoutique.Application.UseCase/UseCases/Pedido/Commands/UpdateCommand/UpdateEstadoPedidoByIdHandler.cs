using AutoMapper;
using MediatR;
using WatchDog;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZBoutique.Utilities;

namespace XYZBoutique.Application.UseCase.UseCases.Pedido.Commands.UpdateCommand
{
    /// <summary>
    /// Manejador para el comando de actualización de estado de pedido por su identificador.
    /// </summary>
    public class UpdateEstadoPedidoByIdHandler : IRequestHandler<UpdateEstadoPedidoByIdCommand, BaseResponse<bool>>
    {
        private readonly IPedidoRepository _pedidoRepository;

        /// <summary>
        /// Inicializa una nueva instancia del manejador con las dependencias requeridas.
        /// </summary>
        /// <param name="pedidoRepository">Repositorio de pedidos.</param>
        public UpdateEstadoPedidoByIdHandler(IPedidoRepository pedidoRepository, IMapper mapper) 
            => (_pedidoRepository) = (pedidoRepository);

        /// <summary>
        /// Maneja la lógica de negocio para actualizar el estado de un pedido.
        /// </summary>
        /// <param name="request">Comando de actualización de estado del pedido.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación de manera controlada.</param>
        /// <returns>Respuesta indicando el resultado de la actualización.</returns>
        public async Task<BaseResponse<bool>> Handle(UpdateEstadoPedidoByIdCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                // Obtener el pedido por su identificador
                var pedidoById = await _pedidoRepository.GetPedidoById(request.IdPedido);

                // Validar que el nuevo estado sigue la secuencia correcta
                if (request.IdEstadoPedido < pedidoById.IdEstadoPedido)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                    response.TotalRecords = 0;
                    return response;
                }

                // Validar que el nuevo estado no supere un límite específico (en este caso, 5)
                if (request.IdEstadoPedido >= 5)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                    response.TotalRecords = 0;
                    return response;
                }

                // Actualizar el estado del pedido según la secuencia
                switch (pedidoById.IdEstadoPedido)
                {
                    case 1:
                        pedidoById.FechaPedido = DateTime.Now;
                        pedidoById.IdEstadoPedido = 2;
                        break;
                    case 2:
                        pedidoById.FechaRecepcion = DateTime.Now;
                        pedidoById.IdEstadoPedido = 3;
                        break;
                    case 3:
                        pedidoById.FechaDespacho = DateTime.Now;
                        pedidoById.IdEstadoPedido = 4;
                        break;
                    case 4:
                        pedidoById.FechaEntrega = DateTime.Now;
                        break;
                }

                // Actualizar el estado del pedido en el repositorio
                var actualizaPedido = await _pedidoRepository.UpdateEstadoPedido(pedidoById);

                // Verifica si la actualizacion del pedido fue exitosa.
                if (actualizaPedido)
                {
                    response.IsSuccess = true;
                    response.Data = actualizaPedido;
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}
