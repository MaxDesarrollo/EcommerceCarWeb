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
    using System.Web.Mvc;
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
        /// The id producto no existente.
        /// </summary>
        private readonly int idProductoNoExistente = 10000;

        /// <summary>
        /// The id producto existente.
        /// </summary>
        private readonly int idProductoExistente = 2;

        /// <summary>
        /// The id usuario existente.
        /// </summary>
        private readonly int idUsuarioExistente = 1;

        /// <summary>
        /// The index.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductoController controller = new ProductoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// The detalle.
        /// </summary>
        [TestMethod]
        public void Detalle()
        {
            // Arrange
            ProductoController controller = new ProductoController();

            // Act
            ViewResult result = controller.Detalle(this.idProductoExistente) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// The detalle no existe.
        /// </summary>
        [TestMethod]
        public void DetalleNoExiste()
        {
            // Arrange
            ProductoController controller = new ProductoController();

            // Act
            ViewResult result = controller.Detalle(this.idProductoNoExistente) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

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
            var producto = this.productoController.ObtenerProducto(this.idProductoExistente);
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
            var producto = this.productoController.ObtenerProducto(this.idProductoNoExistente);
            Result<ProductoDto> resultado = this.serializer.Deserialize<Result<ProductoDto>>(this.serializer.Serialize(producto.Data));

            Assert.AreEqual(true, resultado.Success);
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

        /// <summary>
        /// The guardar producto error.
        /// </summary>
        [TestMethod]
        public void GuardarProductoError()
        {
            string productoDtoString =
                "{\"ProductoId\"l}";
            var res = this.productoController.GuardarProducto(productoDtoString);
            Result<bool> result =
                this.serializer.Deserialize<Result<bool>>(this.serializer.Serialize(res.Data));

            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.Mensaje);
        }

        /// <summary>
        /// The modificar producto error.
        /// </summary>
        [TestMethod]
        public void ModificarProductoError()
        {
            string productoDtoString =
                "{\"ProductoId\"l}";
            var res = this.productoController.ModificarProducto(productoDtoString);
            Result<bool> result =
                this.serializer.Deserialize<Result<bool>>(this.serializer.Serialize(res.Data));

            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.Mensaje);
        }

        /// <summary>
        /// The eliminar producto no exitoso.
        /// </summary>
        [TestMethod]
        public void EliminarProductoNoExitoso()
        {
            var producto = this.productoController.EliminarProducto(this.idProductoNoExistente);
            Result<List<ProductoDto>> result = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto.Data));

            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.Mensaje);
        }

        /// <summary>
        /// The marcar principal producto exitoso.
        /// </summary>
        [TestMethod]
        public void MarcarPrincipalProductoExitoso()
        {
            var producto = this.productoController.MarcarPrincipalProducto(this.idProductoExistente);
            Result<List<ProductoDto>> result = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto.Data));

            var producto2 = this.productoController.MarcarPrincipalProducto(this.idProductoExistente);
            Result<List<ProductoDto>> result2 = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto2.Data));

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Mensaje);

            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(result2.Mensaje);

            Assert.AreNotEqual(result.Mensaje, result2.Mensaje);
        }

        /// <summary>
        /// The marcar principal producto error.
        /// </summary>
        [TestMethod]
        public void MarcarPrincipalProductoError()
        {
            var producto = this.productoController.MarcarPrincipalProducto(this.idProductoNoExistente);
            Result<List<ProductoDto>> result = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto.Data));

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Mensaje, "Error al querer marcar/desmarcar el producto");
        }

        /// <summary>
        /// The obtener productos principales.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosPrincipales()
        {
            var productosPrincipales = this.productoController.ObtenerProductosPrincipales();
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(productosPrincipales.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }

        /// <summary>
        /// The solicitar pedido producto.
        /// </summary>
        [TestMethod]
        public void SolicitarPedidoProductoError()
        {
            var listaProductosDto = this.productoController.SolicitarPedidoProducto(
                this.idUsuarioExistente,
                "asdfasdf");
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(listaProductosDto.Data));

            Assert.IsFalse(resultado.Success);
            Assert.IsNotNull(resultado.Mensaje);
        }

        /// <summary>
        /// The solicitar pedido producto exitoso.
        /// </summary>
        [TestMethod]
        public void SolicitarPedidoProductoExitoso()
        {
            var listaProductosDto = this.productoController.SolicitarPedidoProducto(
                this.idUsuarioExistente,
                "[{\"ProductoId\":2,\"Nombre\":\"Dunlop SP Sport Maxx\",\"Cantidad\":\"1\",\"Precio\":520,\"TipoProducto\":\"Repuestos\"}]");
            Result<int> resultado = this.serializer.Deserialize<Result<int>>(this.serializer.Serialize(listaProductosDto.Data));

            Assert.IsTrue(resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }
    }
}
