using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZBoutique.Application.Dtos
{
    public class ProductoBySkuOrNombreDto
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? Sku { get; set; }

        public string? Tipo { get; set; }

        public string? Etiquetas { get; set; }

        public decimal? Precio { get; set; }

        public string? UnidadMedida { get; set; }
        public int? Stock { get; set; }
        public DateTime? FechaRegistro { get; set; }

    }
}
