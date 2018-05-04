using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    internal class DetalleVentaProductoDto
    {
        private int DetalleVentaProductoID { get; set; }

        private int Cantidad { get; set; }

        DateTime Fecha { get; set; }

        private DateTime Hora { get; set; }

        private int ProductoID { get; set; }

        private int VentaProductoID { get; set; }

    }
}
