using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using WatchDog;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.Interface;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
using XYZPedido = XYZBoutique.Domain.Entities.Pedido;

namespace XYZBoutique.Application.UseCase.UseCases.Pedido.Queries.GetQuery
{
    /// <summary>
    /// Manejador para la consulta de pedidos con filtro.
    /// </summary>
    public class GetPedidosWithFilterHandler : IRequestHandler<GetPedidosWithFilterQuery, BaseResponse<IEnumerable<PedidosWithFilterDto>>>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia del manejador.
        /// </summary>
        /// <param name="pedidoRepository">Repositorio de pedidos.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public GetPedidosWithFilterHandler(IPedidoRepository pedidoRepository, IMapper mapper)
            => (_pedidoRepository, _mapper) = (pedidoRepository, mapper);

        /// <summary>
        /// Maneja la consulta de pedidos con filtro.
        /// </summary>
        /// <param name="request">Consulta de pedidos con filtro.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Respuesta base con una colección de DTOs de pedidos con filtro.</returns>
        public async Task<BaseResponse<IEnumerable<PedidosWithFilterDto>>> Handle(GetPedidosWithFilterQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<PedidosWithFilterDto>>();

            try
            {
                // Construye el filtro de la consulta.
                Expression<Func<XYZPedido, bool>> filtro = null;

                if (!(string.IsNullOrEmpty(request.NroPedido)))
                {
                    filtro = p => p.NroPedido == request.NroPedido;
                }

                // Obtiene los pedidos filtrados del repositorio.
                var pedidos = await _pedidoRepository.GetPedidosWithFilter(filtro);

                // Mapea los pedidos al modelo de DTO.
                var pedidoDto = _mapper.Map<IEnumerable<PedidosWithFilterDto>>(pedidos.ToList());

                // Asigna la respuesta si se obtuvieron resultados.
                if (pedidoDto is not null)
                {
                    response.IsSuccess = true;
                    response.Data = pedidoDto;
                    response.TotalRecords = pedidoDto.Count();
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores y asignación del mensaje de error.
                response.IsSuccess = false;
                response.Message = ex.Message;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}
