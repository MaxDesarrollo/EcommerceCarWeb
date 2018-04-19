using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    class VehiculoDto
    {
        private int InventarioVehiculoID { get; set; }
        private int CantidadDisponible { get; set; }

        private Double Precio { get; set; }

        private string Color { get; set; }

        DateTime Año { get; set; }

    }
}
