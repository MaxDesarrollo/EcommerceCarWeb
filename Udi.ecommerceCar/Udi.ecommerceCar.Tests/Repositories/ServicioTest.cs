// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// Descripción resumida de ServicioTest
    /// </summary>
    [TestClass]
    public class ServicioTest
    {
        /// <summary>
        /// The servicio servicio.
        /// </summary>
        private readonly ServicioServicio servicioServicio = new ServicioServicio();

        //// readonly ServicioController _servicioController = new ServicioController();

        /// <summary>
        /// The obtener servicio existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServicioExisteTest()
        {
            var servicio = this.servicioServicio.ObtenerServicio(2);
            Assert.IsNotNull(servicio);

            // var servicio = _servicioController.ObtenerServicio(2);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicio.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicio no existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServicioNoExisteTest()
        {
            var servicio = this.servicioServicio.ObtenerServicio(10);
            Assert.IsNull(servicio);

            // var servicio = _servicioController.ObtenerServicio(-1);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicio.Data));

            // Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosExisteTest()
        {
            var servicios = this.servicioServicio.ObtenerServicios(0, 10);
            Assert.IsNotNull(servicios);

            // var servicios = _servicioController.ObtenerServicios(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicios.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios sin parámetros existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosSinParametrosExisteTest()
        {
            var servicios = this.servicioServicio.ObtenerServicios(null, null);
            Assert.IsNotNull(servicios);

            // var servicios = _servicioController.ObtenerServicios(0, 10);
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicios.Data));

            // Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The obtener servicios todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerServiciosTodosExisteTest()
        {
            var servicios = this.servicioServicio.ObtenerServiciosTodos();
            Assert.IsNotNull(servicios);

            // var servicios = _servicioController.ObtenerServiciosTodos();
            // JavaScriptSerializer serializer = new JavaScriptSerializer();
            // Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicios.Data));

            // Assert.AreEqual(true, resultado.Success);
        }
    }
}