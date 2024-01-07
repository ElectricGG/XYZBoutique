using AutoMapper;
using MediatR;
using WatchDog;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZBoutique.Application.UseCase.UseCases.Pedidos.Commands.CreateCommand;
using XYZBoutique.Utilities;
using XYZPedido = XYZBoutique.Domain.Entities.Pedido;

namespace XYZBoutique.Application.UseCase.UseCases.Pedido.Commands.CreateCommand
{
    /// <summary>
    /// Manejador para el comando de creación de pedidos.
    /// </summary>
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, BaseResponse<bool>>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly PedidoValidator _validationRulesPedido;

        /// <summary>
        /// Inicializa una nueva instancia del manejador de comandos de creación de pedidos.
        /// </summary>
        /// <param name="pedidoRepository">Repositorio de pedidos para interactuar con la base de datos.</param>
        /// <param name="mapper">Instancia del mapeador utilizado para convertir entre tipos de objetos.</param>
        /// <param name="validationRules">Validador de reglas para el comando de creación de pedidos.</param>
        public CreatePedidoHandler(IPedidoRepository pedidoRepository, IMapper mapper, PedidoValidator validationRulesPedido) 
            => (_pedidoRepository, _mapper, _validationRulesPedido) = (pedidoRepository, mapper, validationRulesPedido);

        /// <summary>
        /// Maneja la creación de un nuevo pedido según la solicitud proporcionada.
        /// </summary>
        /// <param name="request">Solicitud para crear un nuevo pedido.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación de manera controlada.</param>
        /// <returns>Una respuesta que indica el éxito de la operación, junto con mensajes y posibles errores.</returns>
        public async Task<BaseResponse<bool>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {

            // Inicializa la respuesta que se enviará al final del método.
            var response = new BaseResponse<bool>();

            // Valida la solicitud utilizando las reglas de validación específicas para la creación de pedidos.
            var validationResult = await _validationRulesPedido.ValidateAsync(request);

            // Verifica si la validación fue exitosa.
            if (!validationResult.IsValid)
            {
                // Si la validación falla, configura la respuesta con detalles de error y retorna.
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            try
            {
                // Mapea la solicitud de creación de pedido a la entidad del modelo de dominio.
                var rqPedido = _mapper.Map<XYZPedido>(request);

                // Intenta crear el pedido utilizando el repositorio correspondiente.
                var pedidoGenerado = await _pedidoRepository.CreatePedido(rqPedido);

                // Verifica si la creación del pedido fue exitosa.
                if (pedidoGenerado)
                {
                    // Si es exitoso, configura la respuesta con detalles de éxito.
                    response.IsSuccess = true;
                    response.Data = pedidoGenerado;
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    // Si la creación del pedido falla, configura la respuesta con detalles de fallo.
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y configura la respuesta con detalles de error.
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }
            // Retorna la respuesta después de manejar la solicitud.
            return response;
        }
    }
}
