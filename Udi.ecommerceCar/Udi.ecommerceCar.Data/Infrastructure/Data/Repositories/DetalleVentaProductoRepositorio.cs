using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    class DetalleVentaProductoRepositorio : EFRepositorio<DetalleVentaProducto>
    {
        VentaProductoRepositorio ventaProductoRepositorio = new VentaProductoRepositorio();
        // Metodo para GuardarDetalleVentaProducto
        public int GuardarDetalleVentaProducto(int VentaProductoId, List<ProductoDto> listaProductos)
        {
            VentaProductoDto ventaProducto = new VentaProductoDto();
            ventaProducto.VentaId = VentaProductoId;

            ventaProducto = this.ventaProductoRepositorio.ObtenerVentaProducto(ventaProducto);

            int cantidadInsertado = 0;
            foreach (ProductoDto productoDto in listaProductos)
            {
                DetalleVentaProducto detalleVentaProducto = new DetalleVentaProducto();
                detalleVentaProducto.Cantidad = productoDto.Cantidad;
                detalleVentaProducto.Fecha = ventaProducto.Fecha;
                detalleVentaProducto.Hora = ventaProducto.Hora;
                detalleVentaProducto.ProductoID = productoDto.ProductoId;
                detalleVentaProducto.VentaProductoID = ventaProducto.VentaId;

                this.Add(detalleVentaProducto);
                cantidadInsertado++;
            }

            this.SaveChanges();

            return cantidadInsertado;
        }

        public List<DetalleVentaProductoDto> ObtenerDetallesVentasProductosTodos(int VentaProductoId)
        {
            try
            {
                return
                    this.BuildQuery()
                        .Where(x => x.VentaProductoID == VentaProductoId)
                        .Select(
                            ventaProducto =>
                            new DetalleVentaProductoDto()
                            {
                                DetalleVentaProductoId = ventaProducto.DetalleVentaProductoID,
                                Cantidad = ventaProducto.Cantidad,
                                Fecha = ventaProducto.Fecha,
                                Hora = ventaProducto.Hora,
                                ProductoId = ventaProducto.ProductoID,
                                Producto = ventaProducto.Producto.Nombre,
                                Precio = ventaProducto.Producto.Precio,
                                VentaProductoId = ventaProducto.VentaProductoID
                            })
                        .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public decimal GetMontoVentaProducto(VentaProductoDto ventaProductoDto)
        {
            try
            {
                var montoVentaProducto = this.BuildQuery()
                    .Where(x => x.VentaProductoID == ventaProductoDto.VentaId)
                    .Sum(detalleVentaProducto => detalleVentaProducto.Producto.Precio * detalleVentaProducto.Cantidad);

                if (montoVentaProducto != null)
                {
                    return (decimal)montoVentaProducto;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
