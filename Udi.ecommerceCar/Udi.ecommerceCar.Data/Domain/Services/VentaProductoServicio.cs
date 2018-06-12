using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    using Enum = System.Enum;

    public class VentaProductoServicio
    {
        private readonly VentaProductoRepositorio ventaProductoRepositorio;

        public VentaProductoServicio()
        {
            this.ventaProductoRepositorio = new VentaProductoRepositorio();
        }

        public List<VentaProductoDto> ObtenerVentasProductosTodos()
        {
            var listaVentaProductoDto = this.ventaProductoRepositorio.ObtenerVentasProductosTodos();

            foreach (var ventaProducto in listaVentaProductoDto)
            {
                ventaProducto.EstadoSelect = Utilidades.ObtenerSelectVentaProductoEstado(ventaProducto);
            }

            return listaVentaProductoDto;
        }

        public string CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            return this.ventaProductoRepositorio.CambiarEstadoVentaProducto(ventaProductoId, nuevoEstado);
        }
    }
}
