using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using XYZBoutique.Application.Interface;
using XYZBoutique.Domain.Entities;
using XYZBoutique.Infrastructure.Persistences.Context;

namespace XYZBoutique.Infrastructure.Persistences.Repositories
{
    /// <summary>
    /// Implementación del repositorio de pedidos utilizando Entity Framework Core.
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public PedidoRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /// <summary>
        /// Crea un nuevo pedido y actualiza el correlativo.
        /// </summary>
        /// <param name="modelo">Objeto que representa el nuevo pedido.</param>
        /// <returns>True si el pedido se creó correctamente, False en caso contrario.</returns>
        public async Task<bool> CreatePedido(Pedido modelo)
        {
            int recordAffected = 0;
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    // Actualiza el correlativo para el número de documento del pedido
                    Correlativo correlativo = _dbcontext.Correlativos
                        .Where(c => c.NombreTabla == "Pedido").First();

                    correlativo.NumeroDoc = (Convert.ToInt32(correlativo.NumeroDoc) + 1).ToString();
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.Correlativos.Update(correlativo);

                    // Genera el número de pedido con formato específico
                    int CantidadDigitos = 7;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroPedido = ceros + correlativo.NumeroDoc.ToString();
                    numeroPedido = numeroPedido.Substring(numeroPedido.Length - CantidadDigitos, CantidadDigitos);
                    modelo.NroPedido = numeroPedido;

                    // Agrega el nuevo pedido al contexto
                    await _dbcontext.Pedidos.AddAsync(modelo);

                    // Guarda los cambios en la base de datos
                    recordAffected = await _dbcontext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // En caso de error, realiza un rollback de la transacción
                    transaction.Rollback();
                }
            }

            return recordAffected>0;
        }

        /// <summary>
        /// Obtiene un pedido por su ID.
        /// </summary>
        /// <param name="idPedido">ID del pedido a obtener.</param>
        /// <returns>Un objeto que representa el pedido encontrado o null si no existe.</returns>
        public async Task<Pedido> GetPedidoById(int idPedido)
        {
            var pedidos = await _dbcontext.Pedidos.AsNoTracking().FirstOrDefaultAsync(x=> x.IdPedido.Equals(idPedido));
            return pedidos!;
        }

        /// <summary>
        /// Obtiene una consulta IQueryable de pedidos, opcionalmente filtrados por una expresión.
        /// </summary>
        /// <param name="filtro">Expresión de filtro para restringir los resultados (opcional).</param>
        /// <returns>Consulta IQueryable de pedidos.</returns>
        public async Task<IQueryable<Pedido>> GetPedidosWithFilter(Expression<Func<Pedido, bool>> filtro = null)
        {
            IQueryable<Pedido> queryModelo = filtro == null ? _dbcontext.Set<Pedido>().Include(u => u.IdUsuarioSolicitanteNavigation)
                                                                                      .Include(u=> u.IdEstadoPedidoNavigation)
                                                                                      .Include(u=> u.DetallePedido).ThenInclude(dp => dp.IdProductoNavigation)
                                                                : _dbcontext.Set<Pedido>().Where(filtro).Include(u => u.IdUsuarioSolicitanteNavigation)
                                                                                      .Include(u => u.IdEstadoPedidoNavigation)
                                                                                      .Include(u => u.DetallePedido).ThenInclude(dp => dp.IdProductoNavigation);
            return queryModelo;
        }

        /// <summary>
        /// Actualiza el estado de un pedido.
        /// </summary>
        /// <param name="modelo">Objeto que representa el pedido con el nuevo estado.</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
        public async Task<bool> UpdateEstadoPedido(Pedido modelo)
        {
            int recordAffected;

            // Actualiza el estado del pedido en el contexto
            _dbcontext.Pedidos.Update(modelo);

            // Guarda los cambios en la base de datos
            recordAffected = await _dbcontext.SaveChangesAsync();

            return recordAffected > 0;
        }
    }
}
