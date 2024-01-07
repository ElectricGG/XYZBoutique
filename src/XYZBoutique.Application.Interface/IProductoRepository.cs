using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XYZBoutique.Domain.Entities;

namespace XYZBoutique.Application.Interface
{
    public interface IProductoRepository
    {
        Task<IQueryable<Producto>> GetProductos(Expression<Func<Producto, bool>> filtro = null);
    }
}
