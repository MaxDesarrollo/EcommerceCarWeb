using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio productoRepositorio;

        public ProductoServicio()
        {
            this.productoRepositorio = new ProductoRepositorio();
        }

        public int GuardarProducto(Producto producto)
        {
            int pk = productoRepositorio.GuardarProducto(producto);

            return pk;
        }

        public Producto ObtenerProducto(int pk)
        {
            return productoRepositorio.ObtenerProducto(pk);
        }

    }
}
