using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udi.ecommerceCar.Controllers;

namespace Udi.ecommerceCar.Tests.Repositories
{
    /// <summary>
    /// Descripción resumida de ServicioTest
    /// </summary>
    [TestClass]
    public class ServicioTest
    {
        //readonly ServicioServicio _servicioServicio = new ServicioServicio();
        readonly ServicioController _servicioController = new ServicioController();
        
        [TestMethod]
        public void ObtenerServicioExisteTest()
        {
            //var servicio = _servicioServicio.ObtenerServicio(2);
            //Assert.IsNotNull(servicio);

            var servicio = _servicioController.ObtenerServicio(2);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicio.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerServicioNoExisteTest()
        {
            //var servicio = _servicioServicio.ObtenerServicio(10);
            //Assert.IsNull(servicio);

            var servicio = _servicioController.ObtenerServicio(-1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicio.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        [TestMethod]
        public void ObtenerServiciosExisteTest()
        {
            //var servicios = _servicioServicio.ObtenerServicios(0, 10);
            //Assert.IsNotNull(servicios);

            var servicios = _servicioController.ObtenerServicios(0, 10);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicios.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerServiciosTodosExisteTest()
        {
            //var servicios = _servicioServicio.ObtenerServiciosTodos();
            //Assert.IsNotNull(servicios);

            var servicios = _servicioController.ObtenerServiciosTodos();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(servicios.Data));

            Assert.AreEqual(true, resultado.Success);
        }
    }
}
