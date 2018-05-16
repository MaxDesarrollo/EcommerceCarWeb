using System.Collections.Generic;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public ProductoServicio()
        {
            _productoRepositorio = new ProductoRepositorio();
        }

        public int GuardarProducto(ProductoDto producto)
        {
            return _productoRepositorio.GuardarProducto(producto);
        }

        public ProductoDto ObtenerProducto(int pk)
        {
            return _productoRepositorio.ObtenerProducto(pk);
        }

        public List<ProductoDto> ObtenerProductos(int? page, int? size)
        {
            var p = page ?? 0;
            var s = size ?? 10;

            return _productoRepositorio.ObtenerProductos(p, s);
        }

        public List<ProductoDto> ObtenerProductosTodos()
        {
            return _productoRepositorio.ObtenerProductosTodos();
        }
    }
}
