// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The producto repositorio.
    /// </summary>
    internal class ProductoRepositorio : EFRepositorio<Producto>
    {
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
            Producto newProducto = new Producto()
                                       {
                                           ProductoID = producto.ProductoId, 
                                           Nombre = producto.Nombre, 
                                           Descripcion = producto.Descripcion, 
                                           Cantidad = producto.Cantidad, 
                                           DescripcionCorta = producto.DescripcionCorta, 
                                           UrlAmigable = producto.UrlAmigable, 
                                           Puntuacion = producto.Puntuacion, 
                                           Precio = producto.Precio, 
                                           VisibleMain = producto.VisibleMain, 
                                           ImagenID = producto.ImagenId, 
                                           TipoProductoID = producto.TipoProductoId, 
                                       };

            this.Add(newProducto);
            this.SaveChanges();

            return producto.ProductoId;
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
            try
            {
                return
                    this.BuildQuery()
                        .Where(x => x.ProductoID == pk)
                        .Select(
                            producto =>
                            new ProductoDto()
                                {
                                    ProductoId = producto.ProductoID, 
                                    Nombre = producto.Nombre, 
                                    Descripcion = producto.Descripcion, 
                                    Cantidad = producto.Cantidad, 
                                    DescripcionCorta = producto.DescripcionCorta, 
                                    UrlAmigable = producto.UrlAmigable, 
                                    Puntuacion = producto.Puntuacion, 
                                    Precio = producto.Precio, 
                                    VisibleMain = producto.VisibleMain, 
                                    ImagenId = producto.ImagenID, 
                                    TipoProductoId = producto.TipoProductoID, 
                                    TipoProducto = producto.TipoProducto.Nombre
                                })
                        .First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
        
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
        public List<ProductoDto> ObtenerProductos(int page, int size)
        {
            return
                this.BuildQuery()
                    .Select(
                        producto =>
                        new ProductoDto()
                            {
                                ProductoId = producto.ProductoID, 
                                Nombre = producto.Nombre, 
                                Descripcion = producto.Descripcion, 
                                Cantidad = producto.Cantidad, 
                                DescripcionCorta = producto.DescripcionCorta, 
                                UrlAmigable = producto.UrlAmigable, 
                                Puntuacion = producto.Puntuacion, 
                                Precio = producto.Precio, 
                                VisibleMain = producto.VisibleMain, 
                                ImagenId = producto.ImagenID, 
                                TipoProductoId = producto.TipoProductoID, 
                                TipoProducto = producto.TipoProducto.Nombre
                            })
                    .OrderBy(x => x.ProductoId)
                    .Skip(page * size)
                    .Take(size)
                    .ToList();
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
            return
                this.BuildQuery()
                    .Select(
                        producto =>
                        new ProductoDto()
                            {
                                ProductoId = producto.ProductoID, 
                                Nombre = producto.Nombre, 
                                Descripcion = producto.Descripcion, 
                                Cantidad = producto.Cantidad, 
                                DescripcionCorta = producto.DescripcionCorta, 
                                UrlAmigable = producto.UrlAmigable, 
                                Puntuacion = producto.Puntuacion, 
                                Precio = producto.Precio, 
                                VisibleMain = producto.VisibleMain, 
                                ImagenId = producto.ImagenID, 
                                TipoProductoId = producto.TipoProductoID, 
                                TipoProducto = producto.TipoProducto.Nombre
                            })
                    .ToList();
        }

        /// <summary>
        /// The marcar principal producto.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MarcarPrincipalProducto(int id)
        {
            var producto = this.Get(id);

            if (producto.VisibleMain == null)
            {
                producto.VisibleMain = false;
            }

            producto.VisibleMain = !producto.VisibleMain;

            this.SaveChanges();

            return (bool)producto.VisibleMain;
        }

        public List<ProductoDto> ObtenerProductosPrincipales()
        {
            return
                this.BuildQuery()
                    .Where(x => x.VisibleMain == true)
                    .Select(
                        producto =>
                        new ProductoDto()
                        {
                            ProductoId = producto.ProductoID,
                            Nombre = producto.Nombre,
                            Descripcion = producto.Descripcion,
                            Cantidad = producto.Cantidad,
                            DescripcionCorta = producto.DescripcionCorta,
                            UrlAmigable = producto.UrlAmigable,
                            Puntuacion = producto.Puntuacion,
                            Precio = producto.Precio,
                            VisibleMain = producto.VisibleMain,
                            ImagenId = producto.ImagenID,
                            TipoProductoId = producto.TipoProductoID,
                            TipoProducto = producto.TipoProducto.Nombre
                        })
                    .ToList();
        }

        //public void SolicitarPedidoProducto(int idUsuario, List<ProductoDto> listaProductos)
        //{
        //    // Agarrar la lista de productos
        //    // Crear una VentaProducto
        //    VentaProducto ventaProducto = new VentaProducto();
        //    // Llenar los datos
        //    ventaProducto.Monto = 0;
        //    ventaProducto.Fecha = DateTime.Today;
        //    ventaProducto.Hora = DateTime.Now.TimeOfDay;
        //    ventaProducto.UsuarioID = idUsuario;
        //    ventaProducto.Estado = 0;
        //    // Guardar Producto
        //    // Llamar a algo que guarde ventaProducto
        //    // Crear un DetalleVentaProducto
        //    // Llenar los datos
        //    // Llamar a algo que guarde detalleVentaProducto
        //    // Devolver un OK(?)
        //}
        public bool ModificarProducto(ProductoDto productoDto)
        {
            try
            {
                Producto productoUpdate = this.Get(productoDto.ProductoId);
                productoUpdate.Nombre = productoDto.Nombre;
                productoUpdate.Descripcion = productoDto.Descripcion;
                productoUpdate.DescripcionCorta = productoDto.DescripcionCorta;
                productoUpdate.Precio = productoDto.Precio;
                productoUpdate.Cantidad = productoDto.Cantidad;
                productoUpdate.UrlAmigable = productoDto.UrlAmigable;
                productoUpdate.VisibleMain = productoDto.VisibleMain;
                productoUpdate.Puntuacion = productoDto.Puntuacion;
                productoUpdate.ImagenID = productoDto.ImagenId;
                productoUpdate.TipoProductoID = productoDto.TipoProductoId;

                Update(productoUpdate);
                this.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarProducto(int pk)
        {
            try
            {
                Producto producto = this.Get(pk);
                Remove(producto);
                this.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}