using System;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udi.ecommerceCar.Controllers;

namespace Udi.ecommerceCar.Tests.Repositories
{
    [TestClass]
    public class ProductoTest
    {
        //readonly ProductoServicio _productoServicio = new ProductoServicio();
        readonly ProductoController _productoController = new ProductoController();


        [TestMethod]
        public void ObtenerProductoExisteTest()
        {
            //var producto = _productoServicio.ObtenerProducto(2);
            //Assert.IsNotNull(producto);

            var producto = _productoController.ObtenerProducto(2);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(producto.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            //var producto = _productoServicio.ObtenerProducto(10);
            //Assert.IsNull(producto);

            var producto = _productoController.ObtenerProducto(-1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(producto.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        [TestMethod]
        public void ObtenerProductosExisteTest()
        {
            //var preoductos = _productoServicio.ObtenerProductos(0, 10);
            //Assert.IsNotNull(preoductos);

            var productos = _productoController.ObtenerProductos(0, 10);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerProductosTodosExisteTest()
        {
            //var preoductos = _productoServicio.ObtenerProductosTodos();
            //Assert.IsNotNull(preoductos);

            var productos = _productoController.ObtenerProductosTodos();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
        }
    }
}
