// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The vehiculo test.
    /// </summary>
    [TestClass]
    public class VehiculoTest
    {
        /// <summary>
        /// The vehiculo servicio.
        /// </summary>
        private readonly VehiculoServicio vehiculoServicio = new VehiculoServicio();
        
        // private readonly VehiculoController _vehiculoController = new VehiculoController();

        /// <summary>
        /// The obtener vehiculo existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculoExisteTest()
        {
            var vehiculo = this.vehiculoServicio.ObtenerVehiculo(2);
            Assert.IsNotNull(vehiculo);

            // var vehiculo = this._vehiculoController.ObtenerVehiculo(2);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculo.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculo no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculoNoExisteTest()
        {
            var vehiculo = this.vehiculoServicio.ObtenerVehiculo(10);
            Assert.IsNull(vehiculo);

            // var vehiculo = this._vehiculoController.ObtenerVehiculo(-1);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculo.Data));

            // Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosExisteTest()
        {
            var vehiculos = this.vehiculoServicio.ObtenerVehiculos(0, 10);
            Assert.IsNotNull(vehiculos);

            // var vehiculos = this._vehiculoController.ObtenerVehiculos(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos sin parámetros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosSinParametrosExisteTest()
        {
            var vehiculos = this.vehiculoServicio.ObtenerVehiculos(null, null);
            Assert.IsNotNull(vehiculos);

            // var vehiculos = this._vehiculoController.ObtenerVehiculos(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener vehiculos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerVehiculosTodosExisteTest()
        {
            var vehiculos = this.vehiculoServicio.ObtenerVehiculosTodos();
            Assert.IsNotNull(vehiculos);

            // var vehiculos = this._vehiculoController.ObtenerVehiculosTodos();
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculos.Data));

            // Assert.AreEqual(true, resultado.Success);
        }
    }
}