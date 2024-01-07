using MediatR;
using XYZBoutique.Application.Dtos;
using XYZBoutique.Application.UseCase.Commons.Bases.Response;
/// <summary>
/// Query para obtener pedidos con filtro.
/// </summary>
public class GetPedidosWithFilterQuery : IRequest<BaseResponse<IEnumerable<PedidosWithFilterDto>>>
{
    /// <summary>
    /// Obtiene o establece el número de pedido para aplicar el filtro.
    /// </summary>
    public string? NroPedido { get; set; }
}