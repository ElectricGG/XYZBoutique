using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using XYZBoutique.Application.Interface;
using XYZBoutique.Domain.Entities;
using XYZBoutique.Infrastructure.Persistences.Context;

namespace XYZBoutique.Infrastructure.Persistences.Repositories
{
    /// <summary>
    /// Implementación del repositorio de productos utilizando Entity Framework Core.
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ProductoRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /// <summary>
        /// Obtiene una consulta IQueryable de productos, opcionalmente filtrados por una expresión.
        /// </summary>
        /// <param name="filtro">Expresión de filtro para restringir los resultados (opcional).</param>
        /// <returns>Consulta IQueryable de productos.</returns>
        public async Task<IQueryable<Producto>> GetProductos(Expression<Func<Producto, bool>> filtro = null)
        {
            // Construye la consulta IQueryable de productos con o sin filtro, incluyendo las relaciones necesarias.
            IQueryable<Producto> queryModelo = filtro == null ? _dbcontext.Set<Producto>()
                                                                    .Include(u => u.IdTipoNavigation)
                                                                    .Include(u => u.IdUnidadMedidaNavigation)
                                                                : _dbcontext.Set<Producto>().Where(filtro)
                                                                .Include(u => u.IdTipoNavigation)
                                                                .Include(u => u.IdUnidadMedidaNavigation);
            return queryModelo;
        }
    }
}
