// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilidades.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;

    /// <summary>
    /// The utilidades.
    /// </summary>
    public static class Utilidades
    {
        /// <summary>
        /// The obtener select venta producto estado.
        /// </summary>
        /// <param name="ventaProducto">
        /// The venta producto.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ObtenerSelectVentaProductoEstado(VentaProductoDto ventaProducto)
        {
            string previousOption = string.Empty, nextOption = string.Empty;
            string select = "<select class='slt-venta-producto-estado' data-estado-actual='" + ventaProducto.Estado
                            + "'>";

            if (ventaProducto.Estado - 1 >= 0)
            {
                if (ventaProducto.Estado != null)
                {
                    previousOption = "<option value='" + (ventaProducto.Estado - 1) + "'>"
                                     + (VentaEstado)(ventaProducto.Estado - 1) + "</option>";
                }
            }

            // ventaProducto.Estado + 1 < Enum.GetNames(typeof(VentaEstado)).Length && 
            if (ventaProducto.Estado + 1 < (int)VentaEstado.CanceladoPorAdministrador)
            {
                if (ventaProducto.Estado != null)
                {
                    nextOption = "<option value='" + (ventaProducto.Estado + 1) + "'>"
                                 + (VentaEstado)(ventaProducto.Estado + 1) + "</option>";
                }
            }

            string currentOption = "<option value='" + ventaProducto.Estado + "' selected='selected'>"
                                   + ventaProducto.EstadoString + "</option>";
            string cancelOption = "<option value='" + (int)VentaEstado.CanceladoPorAdministrador + "'>Cancelar</option>";
            select += previousOption + currentOption + nextOption + cancelOption;
            select += "</select>";

            return select;
        }
    }
}