using System.Linq.Expressions;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.Interface
{
    public interface IPedidoRepository
    {
        Task<bool> CreatePedido(Pedido pedido);
        Task<Pedido> GetPedidoById(int idPedido);
        Task<IQueryable<Pedido>> GetPedidosWithFilter(Expression<Func<Pedido, bool>> filtro = null);
        Task<bool> UpdateEstadoPedido(Pedido pedido);
    }
}
