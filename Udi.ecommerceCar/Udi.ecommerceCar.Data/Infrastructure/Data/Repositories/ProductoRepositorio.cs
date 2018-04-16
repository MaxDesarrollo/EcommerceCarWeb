using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                TipoProductoID = producto.TipoProductoID
            };

            Add(newProducto);
            SaveChanges();

            return producto.ProductoID;
        }

        public ProductoDto ObtenerProducto(int pk)
        {
            Producto producto = Get(pk);
            return new ProductoDto()
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,
                TipoProductoID = producto.TipoProductoID,
                TipoProducto = producto.TipoProducto.Nombre
            };
        }

        public List<ProductoDto> ObtenerProductos()
        {
            return this.BuildQuery().Select(producto => new ProductoDto()
            {
                ProductoID = producto.ProductoID,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,
                TipoProductoID = producto.TipoProductoID,
                TipoProducto = producto.TipoProducto.Nombre
            }).ToList();
        }
    }
}
