using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udi.ecommerceCar.Controllers;

namespace Udi.ecommerceCar.Tests.Repositories
{
    [TestClass]
    public class VehiculoTest
    {
        //readonly VehiculoServicio _vehiculoServicio = new VehiculoServicio();
        readonly VehiculoController _vehiculoController = new VehiculoController();

        [TestMethod]
        public void ObtenerVehiculoExisteTest()
        {
            //var vehiculo = _vehiculoServicio.ObtenerVehiculo(2);
            //Assert.IsNotNull(vehiculo);

            var vehiculo = _vehiculoController.ObtenerVehiculo(2);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculo.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerVehiculoNoExisteTest()
        {
            //var vehiculo = _vehiculoServicio.ObtenerVehiculo(10);
            //Assert.IsNull(vehiculo);

            var vehiculo = _vehiculoController.ObtenerVehiculo(-1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculo.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        [TestMethod]
        public void ObtenerVehiculosExisteTest()
        {
            //var vehiculos = _vehiculoServicio.ObtenerVehiculos(0, 10);
            //Assert.IsNotNull(vehiculos);

            var vehiculos = _vehiculoController.ObtenerVehiculos(0, 10);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculos.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void ObtenerVehiculosTodosExisteTest()
        {
            //var vehiculos = _vehiculoServicio.ObtenerVehiculosTodos();
            //Assert.IsNotNull(vehiculos);

            var vehiculos = _vehiculoController.ObtenerVehiculosTodos();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(vehiculos.Data));

            Assert.AreEqual(true, resultado.Success);
        }
    }
}
