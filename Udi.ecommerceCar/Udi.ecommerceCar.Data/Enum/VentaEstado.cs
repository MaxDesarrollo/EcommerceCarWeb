using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Enum
{
    public enum VentaEstado : int
    {
        Pendiente = 0,
        Pagado = 1,
        Enviado = 2,
        Completado = 3,
        CanceladoPorAdministrador = 4,
        CanceladoPorCliente = 5
    }
}
