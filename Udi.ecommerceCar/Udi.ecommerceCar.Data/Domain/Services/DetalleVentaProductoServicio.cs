using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    public class DetalleVentaProductoServicio
    {
        private readonly DetalleVentaProductoRepositorio detalleVentaProductoRepositorio;

        public DetalleVentaProductoServicio()
        {
            this.detalleVentaProductoRepositorio = new DetalleVentaProductoRepositorio();
        }

        public List<DetalleVentaProductoDto> ObtenerDetallesVentasProductosTodos(int VentaProductoId)
        {
            return this.detalleVentaProductoRepositorio.ObtenerDetallesVentasProductosTodos(VentaProductoId);
        }
    }
}
