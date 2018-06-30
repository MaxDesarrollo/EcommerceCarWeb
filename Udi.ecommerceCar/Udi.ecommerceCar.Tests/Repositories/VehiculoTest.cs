// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoTest.cs" company="MC Autoventas">
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
    /// The vehiculo test.
    /// </summary>
    [TestClass]
    public class VehiculoTest
    {
        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        ///// <summary>
        ///// The vehiculo servicio.
        ///// </summary>
        // private readonly VehiculoServicio vehiculoServicio = new VehiculoServicio();

        /// <summary>
        /// The vehiculo controller.
        /// </summary>
        private readonly VehiculoController vehiculoController = new VehiculoController();

        /// <summary>
        /// The id vehiculo no existente.
        /// </summary>
        private readonly int idVehiculoNoExistente = 10000;

        /// <summary>
        /// The id vehiculo existente.
        /// </summary>
        private readonly int idVehiculoExistente = 2;

        /// <summary>
        /// The obtener vehiculo existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculoExisteTest()
        {
            var vehiculo = this.vehiculoController.ObtenerVehiculo(this.idVehiculoExistente);
            Result<VehiculoDto> resultado = this.serializer.Deserialize<Result<VehiculoDto>>(this.serializer.Serialize(vehiculo.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.AreEqual("Pathfinder", resultado.Data.NombreModelo);
            Assert.AreEqual("Nissan", resultado.Data.NombreMarca);
        }

        /// <summary>
        /// The obtener vehiculo no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculoNoExisteTest()
        {
            var vehiculo = this.vehiculoController.ObtenerVehiculo(this.idVehiculoNoExistente);
            Result<VehiculoDto> resultado = this.serializer.Deserialize<Result<VehiculoDto>>(this.serializer.Serialize(vehiculo.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosExisteTest()
        {
            var vehiculos = this.vehiculoController.ObtenerVehiculos(0, 10);
            Result<List<VehiculoDto>> resultado = this.serializer.Deserialize<Result<List<VehiculoDto>>>(this.serializer.Serialize(vehiculos.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos sin parámetros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosSinParametrosExisteTest()
        {
            var vehiculos = this.vehiculoController.ObtenerVehiculos(null, null);
            Result<List<VehiculoDto>> resultado = this.serializer.Deserialize<Result<List<VehiculoDto>>>(this.serializer.Serialize(vehiculos.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosTodosExisteTest()
        {
            var vehiculos = this.vehiculoController.ObtenerVehiculosTodos();
            Result<List<VehiculoDto>> resultado = this.serializer.Deserialize<Result<List<VehiculoDto>>>(this.serializer.Serialize(vehiculos.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The marcar principal vehiculo exitoso.
        /// </summary>
        [TestMethod]
        public void MarcarPrincipalVehiculoExitoso()
        {
            var vehiculo = this.vehiculoController.MarcarPrincipalVehiculo(this.idVehiculoExistente);
            Result<List<ProductoDto>> result = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(vehiculo.Data));

            var vehiculo2 = this.vehiculoController.MarcarPrincipalVehiculo(this.idVehiculoExistente);
            Result<List<ProductoDto>> result2 = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(vehiculo2.Data));

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Mensaje);

            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(result2.Mensaje);

            Assert.AreNotEqual(result.Mensaje, result2.Mensaje);
        }

        /// <summary>
        /// The obtener vehiculos principales.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosPrincipales()
        {
            var vehiculosPrincipales = this.vehiculoController.ObtenerVehiculosPrincipales();
            Result<List<ProductoDto>> resultado = this.serializer.Deserialize<Result<List<ProductoDto>>>(this.serializer.Serialize(vehiculosPrincipales.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.IsNotNull(resultado.Data);
        }
    }
}