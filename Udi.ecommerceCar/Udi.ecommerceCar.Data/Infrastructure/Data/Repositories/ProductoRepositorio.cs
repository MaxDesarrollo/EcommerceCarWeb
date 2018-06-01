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
                                           ProductoID = producto.ProductoID, 
                                           Nombre = producto.Nombre, 
                                           Descripcion = producto.Descripcion, 
                                           DescripcionCorta = producto.DescripcionCorta, 
                                           Cantidad = producto.Cantidad, 
                                           Precio = producto.Precio, 
                                           TipoProductoID = producto.TipoProductoID
                                       };

            this.Add(newProducto);
            this.SaveChanges();

            return producto.ProductoID;
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
                                    ProductoID = producto.ProductoID, 
                                    Nombre = producto.Nombre, 
                                    Descripcion = producto.Descripcion, 
                                    DescripcionCorta = producto.DescripcionCorta, 
                                    Cantidad = producto.Cantidad, 
                                    Precio = producto.Precio, 
                                    TipoProductoID = producto.TipoProductoID, 
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
        /// The <see cref="List"/>.
        /// </returns>
        public List<ProductoDto> ObtenerProductos(int page, int size)
        {
            return
                this.BuildQuery()
                    .Select(
                        producto =>
                        new ProductoDto()
                            {
                                ProductoID = producto.ProductoID, 
                                Nombre = producto.Nombre, 
                                Descripcion = producto.Descripcion, 
                                DescripcionCorta = producto.DescripcionCorta, 
                                Cantidad = producto.Cantidad, 
                                Precio = producto.Precio, 
                                TipoProductoID = producto.TipoProductoID, 
                                TipoProducto = producto.TipoProducto.Nombre
                            })
                    .OrderBy(x => x.ProductoID)
                    .Skip(page * size)
                    .Take(size)
                    .ToList();
        }

        /// <summary>
        /// The obtener productos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<ProductoDto> ObtenerProductosTodos()
        {
            return
                this.BuildQuery()
                    .Select(
                        producto =>
                        new ProductoDto()
                            {
                                ProductoID = producto.ProductoID, 
                                Nombre = producto.Nombre, 
                                Descripcion = producto.Descripcion, 
                                DescripcionCorta = producto.DescripcionCorta, 
                                Cantidad = producto.Cantidad, 
                                Precio = producto.Precio, 
                                TipoProductoID = producto.TipoProductoID, 
                                TipoProducto = producto.TipoProducto.Nombre
                            })
                    .ToList();
        }
    }
}