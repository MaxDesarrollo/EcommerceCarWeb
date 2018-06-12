using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;

    public static class Utilidades
    {
        public static string ObtenerSelectVentaProductoEstado(VentaProductoDto ventaProducto)
        {
            string previousOption = string.Empty, nextOption = string.Empty;
            string select = "<select class='slt-venta-producto-estado' data-estado-actual='" + ventaProducto.Estado + "'>";

            if (ventaProducto.Estado - 1 >= 0)
            {
                if (ventaProducto.Estado != null)
                {
                    previousOption = "<option value='" + (ventaProducto.Estado - 1) + "'>" + (VentaEstado)(ventaProducto.Estado - 1) + "</option>";
                }
            }

            // ventaProducto.Estado + 1 < Enum.GetNames(typeof(VentaEstado)).Length && 
            if (ventaProducto.Estado + 1 < (int)VentaEstado.CanceladoPorAdministrador)
            {
                if (ventaProducto.Estado != null)
                {
                    nextOption = "<option value='" + (ventaProducto.Estado + 1) + "'>" + (VentaEstado)(ventaProducto.Estado + 1) + "</option>";
                }
            }

            string currentOption = "<option value='" + ventaProducto.Estado + "' selected='selected'>" + ventaProducto.EstadoString + "</option>";
            string cancelOption = "<option value='" + (int)VentaEstado.CanceladoPorAdministrador + "'>Cancelar</option>";
            select += previousOption + currentOption + nextOption + cancelOption;
            select += "</select>";

            return select;
        }
    }
}
