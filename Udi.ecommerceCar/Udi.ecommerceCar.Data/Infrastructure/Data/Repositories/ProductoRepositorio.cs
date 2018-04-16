using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class ProductoRepositorio : EFRepositorio<Producto>
    {
        public int GuardarProducto(Producto producto)
        {
            Producto newProducto = new Producto()
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = producto.Cantidad,
                TipoProductoID = producto.TipoProductoID
            };

            Add(newProducto);
            SaveChanges();

            return producto.ProductoID;
        }

        public Producto ObtenerProducto(int pk)
        {
            return Get(pk);
        }
    }
}
