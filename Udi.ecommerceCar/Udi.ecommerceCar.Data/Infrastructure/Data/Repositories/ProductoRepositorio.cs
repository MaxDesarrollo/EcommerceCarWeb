using System;
using System.Collections.Generic;
using System.Linq;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class ProductoRepositorio : EFRepositorio<Producto>
    {
        public int GuardarProducto(ProductoDto producto)
        {
            Producto newProducto = new Producto()
            {
                ProductoID = producto.ProductoID,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,

                DescripcionCorta = producto.DescripcionCorta,
                UrlAmigable = producto.UrlAmigable,
                Puntuacion = producto.Puntuacion,
                Precio = producto.Precio,
                VisibleMain = producto.VisibleMain,

                ImagenID = producto.ImagenId,
                TipoProductoID = producto.TipoProductoID,

            };

            Add(newProducto);
            SaveChanges();

            return producto.ProductoID;
        }

        public ProductoDto ObtenerProducto(int pk)
        {
            try
            {
                return BuildQuery().Where(x => x.ProductoID == pk).Select(producto => new ProductoDto()
                {
                    ProductoID = producto.ProductoID,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Cantidad = producto.Cantidad,

                    DescripcionCorta = producto.DescripcionCorta,
                    UrlAmigable = producto.UrlAmigable,
                    Puntuacion = producto.Puntuacion,
                    Precio = producto.Precio,
                    VisibleMain = producto.VisibleMain,

                    ImagenId = producto.ImagenID,
                    TipoProductoID = producto.TipoProductoID,
                    TipoProducto = producto.TipoProducto.Nombre
                }).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
        public List<ProductoDto> ObtenerProductos(int page, int size)
        {
            return BuildQuery().Select(producto => new ProductoDto()
            {
                ProductoID = producto.ProductoID,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,

                DescripcionCorta = producto.DescripcionCorta,
                UrlAmigable = producto.UrlAmigable,
                Puntuacion = producto.Puntuacion,
                Precio = producto.Precio,
                VisibleMain = producto.VisibleMain,

                ImagenId = producto.ImagenID,
                TipoProductoID = producto.TipoProductoID,
                TipoProducto = producto.TipoProducto.Nombre
            })
            .OrderBy(x => x.ProductoID)
            .Skip(page * size)
            .Take(size)
            .ToList();
        }

        public List<ProductoDto> ObtenerProductosTodos()
        {
            return BuildQuery().Select(producto => new ProductoDto()
            {
                ProductoID = producto.ProductoID,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,

                DescripcionCorta = producto.DescripcionCorta,
                UrlAmigable = producto.UrlAmigable,
                Puntuacion = producto.Puntuacion,
                Precio = producto.Precio,
                VisibleMain = producto.VisibleMain,

                ImagenId = producto.ImagenID,
                TipoProductoID = producto.TipoProductoID,
                TipoProducto = producto.TipoProducto.Nombre
            })
            .ToList();
        }
    }
}
