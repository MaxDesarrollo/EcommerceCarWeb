// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Controllers;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// Descripción resumida de ServicioTest
    /// </summary>
    [TestClass]
    public class ServicioTest
    {
        ///// <summary>
        ///// The servicio servicio.
        ///// </summary>
        // private readonly ServicioServicio servicioServicio = new ServicioServicio();

        /// <summary>
        /// The _servicio controller.
        /// </summary>
        private readonly ServicioController servicioController = new ServicioController();

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        /// <summary>
        /// The id servicio no existente.
        /// </summary>
        private readonly int idServicioNoExistente = 10000;

        /// <summary>
        /// The id servicio existente.
        /// </summary>
        private readonly int idServicioExistente = 2;

        /// <summary>
        /// The obtener servicio existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServicioExisteTest()
        {
            var servicio = this.servicioController.ObtenerServicio(this.idServicioExistente);
            Result<ServicioDto> resultado = this.serializer.Deserialize<Result<ServicioDto>>(this.serializer.Serialize(servicio.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicio no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServicioNoExisteTest()
        {
            var servicio = this.servicioController.ObtenerServicio(this.idServicioNoExistente);
            Result<ServicioDto> resultado = this.serializer.Deserialize<Result<ServicioDto>>(this.serializer.Serialize(servicio.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosExisteTest()
        {
            var servicios = this.servicioController.ObtenerServicios(0, 10);
            Result<List<ServicioDto>> resultado = this.serializer.Deserialize<Result<List<ServicioDto>>>(this.serializer.Serialize(servicios.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios sin parametros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosSinParametrosExisteTest()
        {
            var servicios = this.servicioController.ObtenerServicios(null, null);
            Result<List<ServicioDto>> resultado = this.serializer.Deserialize<Result<List<ServicioDto>>>(this.serializer.Serialize(servicios.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosTodosExisteTest()
        {
            var servicios = this.servicioController.ObtenerServiciosTodos();
            Result<List<ServicioDto>> resultado = this.serializer.Deserialize<Result<List<ServicioDto>>>(this.serializer.Serialize(servicios.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The marcar principal producto exitoso.
        /// </summary>
        [TestMethod]
        public void MarcarPrincipalServicioExitoso()
        {
            var producto = this.servicioController.MarcarPrincipalServicio(this.idServicioExistente);
            Result<List<ProductoDto>> result = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto.Data));

            var producto2 = this.servicioController.MarcarPrincipalServicio(this.idServicioExistente);
            Result<List<ProductoDto>> result2 = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(producto2.Data));

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Mensaje);

            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(result2.Mensaje);

            Assert.AreNotEqual(result.Mensaje, result2.Mensaje);
        }

        /// <summary>
        /// The obtener productos principales.
        /// </summary>
        [TestMethod]
        public void ObtenerProductosPrincipales()
        {
            var serviciosPrincipales = this.servicioController.ObtenerServiciosPrincipales();
            Result<List<ServicioDto>> resultado = this.serializer.Deserialize<Result<List<ServicioDto>>>(this.serializer.Serialize(serviciosPrincipales.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }
    }
}