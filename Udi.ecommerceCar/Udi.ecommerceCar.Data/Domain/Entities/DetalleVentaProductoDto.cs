using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    public class DetalleVentaProductoDto
    {
        public int DetalleVentaProductoId { get; set; }

        public int? Cantidad { get; set; }

        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public int? ProductoId { get; set; }

        public string Producto { get; set; }

        public decimal? Precio { get; set; }

        public int? VentaProductoId { get; set; }
    }
}
