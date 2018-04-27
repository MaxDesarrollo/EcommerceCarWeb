﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    class DetalleVentaVehiculoDto
    {
        private int DetalleVentaVehiculo { get; set; }
        int Cantidad { get; set; }
        private double Monto { get; set; }

        private DateTime Fecha { get; set; }

        private DateTime Hora { get; set; }

        private int InventarioVehiculo { get; set; }

        private int VentaVehiculo { get; set; }
    }
}
