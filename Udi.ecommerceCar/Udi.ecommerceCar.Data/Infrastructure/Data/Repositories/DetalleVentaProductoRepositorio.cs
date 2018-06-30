// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetalleVentaProductoRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The detalle venta producto repositorio.
    /// </summary>
    internal class DetalleVentaProductoRepositorio : EFRepositorio<DetalleVentaProducto>
    {
        /// <summary>
        /// The venta producto repositorio.
        /// </summary>
        private readonly VentaProductoRepositorio ventaProductoRepositorio = new VentaProductoRepositorio();

        /// <summary>
        /// The get monto venta producto.
        /// </summary>
        /// <param name="ventaProductoDto">
        /// The venta producto dto.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public decimal GetMontoVentaProducto(VentaProductoDto ventaProductoDto)
        {
            try
            {
                var montoVentaProducto =
                    this.BuildQuery()
                        .Where(x => x.VentaProductoID == ventaProductoDto.VentaId)
                        .Sum(
                            detalleVentaProducto => detalleVentaProducto.Producto.Precio * detalleVentaProducto.Cantidad);

                if (montoVentaProducto != null)
                {
                    return (decimal)montoVentaProducto;
                }

                return 0;
            }
            catch (ExcepcionComercio)
            {
                return 0;
            }
        }
        
        /// <summary>
        /// The guardar detalle venta producto.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <param name="listaProductos">
        /// The lista productos.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GuardarDetalleVentaProducto(int ventaProductoId, List<ProductoDto> listaProductos)
        {
            VentaProductoDto ventaProducto = new VentaProductoDto();
            ventaProducto.VentaId = ventaProductoId;

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

        /// <summary>
        /// The obtener detalles ventas productos todos.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<DetalleVentaProductoDto> ObtenerDetallesVentasProductosTodos(int ventaProductoId)
        {
            try
            {
                return
                    this.BuildQuery()
                        .Where(x => x.VentaProductoID == ventaProductoId)
                        .Select(
                            ventaProducto =>
                            new DetalleVentaProductoDto()
                                {
                                    DetalleVentaProductoId =
                                        ventaProducto.DetalleVentaProductoID, 
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
            catch (ExcepcionComercio)
            {
                return null;
            }
        }
    }
}