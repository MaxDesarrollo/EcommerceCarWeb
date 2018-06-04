// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// <summary>
//   Defines the ProductoTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The producto test.
    /// </summary>
    [TestClass]
    public class ProductoTest
    {
        /// <summary>
        /// The producto servicio.
        /// </summary>
        private readonly ProductoServicio productoServicio = new ProductoServicio();

        // readonly ProductoController _productoController = new ProductoController();

        /// <summary>
        /// The obtener producto existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductoExisteTest()
        {
            var producto = this.productoServicio.ObtenerProducto(2);
            Assert.IsNotNull(producto);

            // var producto = _productoController.ObtenerProducto(2);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(producto.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener producto no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            var producto = this.productoServicio.ObtenerProducto(10);
            Assert.IsNull(producto);

            // var producto = _productoController.ObtenerProducto(-1);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(producto.Data));

            // Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener productos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosExisteTest()
        {
            var productos = this.productoServicio.ObtenerProductos(0, 10);
            Assert.IsNotNull(productos);

            // var productos = _productoController.ObtenerProductos(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(productos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener productos sin parametros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosSinParametrosExisteTest()
        {
            var productos = this.productoServicio.ObtenerProductos(null, null);
            Assert.IsNotNull(productos);

            // var productos = _productoController.ObtenerProductos(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(productos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener productos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosTodosExisteTest()
        {
            var preoductos = this.productoServicio.ObtenerProductosTodos();
            Assert.IsNotNull(preoductos);

            // var productos = _productoController.ObtenerProductosTodos();
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(productos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }
    }
}
