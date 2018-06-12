// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The producto servicio.
    /// </summary>
    public class ProductoServicio
    {
        /// <summary>
        /// The _producto repositorio.
        /// </summary>
        private readonly ProductoRepositorio productoRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductoServicio"/> class.
        /// </summary>
        public ProductoServicio()
        {
            this.productoRepositorio = new ProductoRepositorio();
        }

        /// <summary>
        /// The guardar producto.
        /// </summary>
        /// <param name="producto">
        /// The producto.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GuardarProducto(ProductoDto producto)
        {
            return this.productoRepositorio.GuardarProducto(producto);
        }

        /// <summary>
        /// The obtener producto.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="ProductoDto"/>.
        /// </returns>
        public ProductoDto ObtenerProducto(int pk)
        {
            return this.productoRepositorio.ObtenerProducto(pk);
        }

        /// <summary>
        /// The obtener productos.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<ProductoDto> ObtenerProductos(int? page, int? size)
        {
            var p = page ?? 0;
            var s = size ?? 10;

            return this.productoRepositorio.ObtenerProductos(p, s);
        }

        /// <summary>
        /// The obtener productos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<ProductoDto> ObtenerProductosTodos()
        {
            return this.productoRepositorio.ObtenerProductosTodos();
        }


        public bool MarcarPrincipalProducto(int id)
        {
            return this.productoRepositorio.MarcarPrincipalProducto(id);
        }

        public List<ProductoDto> ObtenerProductosPrincipales()
        {
            return this.productoRepositorio.ObtenerProductosPrincipales();
        }

        public int SolicitarPedidoProducto(int UsuarioId, List<ProductoDto> listaProductos)
        {
            VentaProductoRepositorio ventaProductoRepositorio = new VentaProductoRepositorio();

            VentaProductoDto ventaProductoDto = new VentaProductoDto();
            ventaProductoDto.UsuarioId = UsuarioId;
            ventaProductoDto.Estado = (int)VentaEstado.Pendiente;
            int idVentaProducto = ventaProductoRepositorio.GuardarVentaProducto(ventaProductoDto);
            ventaProductoDto.VentaId = idVentaProducto;

            // Si es nulo, o algo asi, Chau, mensaje de error
            
            DetalleVentaProductoRepositorio detalleVentaProductoRepositorio = new DetalleVentaProductoRepositorio();
            int cantidadInsertado = detalleVentaProductoRepositorio.GuardarDetalleVentaProducto(idVentaProducto, listaProductos);

            decimal montoVentaProducto = detalleVentaProductoRepositorio.GetMontoVentaProducto(ventaProductoDto);
            ventaProductoDto.Monto = montoVentaProducto;
            ventaProductoRepositorio.CambiarMontoVentaProducto(ventaProductoDto);
            
            return cantidadInsertado;
        }

        public bool ModificarProducto(ProductoDto productoDto)
        {
            return this.productoRepositorio.ModificarProducto(productoDto);
        }

        public bool EliminarProducto(int pk)
        {
            return this.productoRepositorio.EliminarProducto(pk);
        }
    }
}