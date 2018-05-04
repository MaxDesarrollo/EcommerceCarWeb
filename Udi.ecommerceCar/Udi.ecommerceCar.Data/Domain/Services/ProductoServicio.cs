using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
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

        public int GuardarProducto(ProductoDto producto)
        {
            int pk = productoRepositorio.GuardarProducto(producto);
            return pk;
        }

        public ProductoDto ObtenerProducto(int pk)
        {
            return productoRepositorio.ObtenerProducto(pk);
        }

        public List<ProductoDto> ObtenerProductos(int? page, int? size)
        {
            int p = page == null ? 10 : (int)page;
            int s = size == null ? 10 : (int)size;

            return productoRepositorio.ObtenerProductos(p, s);
        }

        public List<ProductoDto> ObtenerProductosTodos()
        {
            return productoRepositorio.ObtenerProductosTodos();
        }
    }
}
