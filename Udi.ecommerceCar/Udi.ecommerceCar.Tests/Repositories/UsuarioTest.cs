using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Udi.ecommerceCar.Controllers;

namespace Udi.ecommerceCar.Tests.Repositories
{
    /// <summary>
    /// Descripción resumida de UsuarioTest
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        readonly UsuarioController _usuarioController = new UsuarioController();

        [TestMethod]
        public void ObtenerUsuario()
        {
            var usuario = _usuarioController.ObtenerUsuario(1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(usuario.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void IniciarSesionExitoso()
        {
            var usuario = _usuarioController.IniciarSesion("Raiden", "raiden");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(usuario.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        [TestMethod]
        public void IniciarSesionNoExitoso()
        {
            var usuario = _usuarioController.IniciarSesion("asldk", "asdf");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result resultado = serializer.Deserialize<Result>(serializer.Serialize(usuario.Data));

            Assert.AreEqual(false, resultado.Success);
        }
    }
}
