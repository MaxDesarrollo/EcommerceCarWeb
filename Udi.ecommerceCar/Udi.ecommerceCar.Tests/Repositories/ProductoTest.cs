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
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Controllers;
    using Udi.ecommerceCar.Data.Domain.Entities;

    /// <summary>
    /// The producto test.
    /// </summary>
    [TestClass]
    public class ProductoTest
    {
        /// <summary>
        /// The producto controller.
        /// </summary>
        private readonly ProductoController productoController = new ProductoController();

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        /// <summary>
        /// The guardar producto test.
        /// </summary>
        [TestMethod]
        public void AbmProductoTest()
        {
            string productoDtoString =
                "{\"ProductoId\":0,\"Nombre\":\"Nombre Prueba\",\"Descripcion\":\"Descripcion Prueba\",\"DescripcionCorta\":\"Descripcion Corta Prueba\",\"Cantidad\":\"1522\",\"Precio\":\"1522\",\"VisibleMain\":false,\"TipoProductoId\":\"1\",\"Puntuacion\":null,\"UrlAmigable\":null,\"ImagenId\":null,\"TipoProducto\":null}";
            var res = this.productoController.GuardarProducto(productoDtoString);
            Result<int> resultadoGuardado =
                this.serializer.Deserialize<Result<int>>(this.serializer.Serialize(res.Data));
            
            string productoModificadoDtoString =
                "{\"ProductoId\":\"" + resultadoGuardado.Data + "\",\"Nombre\":\"Nombre modificado Prueba\",\"Descripcion\":\"Descripcion modificada Prueba\",\"DescripcionCorta\":\"Descripcion Corta Prueba\",\"Cantidad\":\"1522\",\"Precio\":\"1522\",\"VisibleMain\":false,\"TipoProductoId\":\"1\",\"Puntuacion\":null,\"UrlAmigable\":null,\"ImagenId\":null,\"TipoProducto\":null}";
            res = this.productoController.ModificarProducto(productoModificadoDtoString);
            Result<bool> resultadoModificado =
                this.serializer.Deserialize<Result<bool>>(this.serializer.Serialize(res.Data));

            res = this.productoController.EliminarProducto(resultadoGuardado.Data);
            Result<bool> resultadoEliminado =
                this.serializer.Deserialize<Result<bool>>(this.serializer.Serialize(res.Data));

            Assert.IsNotNull(resultadoGuardado.Data);
            Assert.IsTrue(resultadoModificado.Data);
            Assert.IsTrue(resultadoEliminado.Data);
        }

        /// <summary>
        /// The obtener producto existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductoExisteTest()
        {
            var producto = this.productoController.ObtenerProducto(2);
            Result<ProductoDto> resultado = this.serializer.Deserialize<Result<ProductoDto>>(this.serializer.Serialize(producto.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.AreEqual("Dunlop SP Sport Maxx", resultado.Data.Nombre);
        }

        /// <summary>
        /// The obtener producto no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductoNoExisteTest()
        {
            var producto = this.productoController.ObtenerProducto(100);
            Result<ProductoDto> resultado = this.serializer.Deserialize<Result<ProductoDto>>(this.serializer.Serialize(producto.Data));

            Assert.AreEqual(false, resultado.Success);
            Assert.IsNull(resultado.Data);
        }

        /// <summary>
        /// The obtener productos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosExisteTest()
        {
            var productos = this.productoController.ObtenerProductos(0, 10);
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }

        /// <summary>
        /// The obtener productos sin parametros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosSinParametrosExisteTest()
        {
            var productos = this.productoController.ObtenerProductos(null, null);
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }

        /// <summary>
        /// The obtener productos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosTodosExisteTest()
        {
            var productos = this.productoController.ObtenerProductosTodos();
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }
    }
}
