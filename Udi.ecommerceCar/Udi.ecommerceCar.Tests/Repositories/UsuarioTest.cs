// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using System.Web.Script.Serialization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Controllers;
    using Udi.ecommerceCar.Data.Domain.Entities;

    /// <summary>
    /// Descripción resumida de UsuarioTest
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        /// <summary>
        /// The _usuario controller.
        /// </summary>
        private readonly UsuarioController usuarioController = new UsuarioController();

        /// <summary>
        /// The iniciar sesion exitoso.
        /// </summary>
        [TestMethod]
        public void IniciarSesionExitoso()
        {
            var usuario = this.usuarioController.IniciarSesion("Raiden", "raiden");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result<UsuarioDto> resultado = serializer.Deserialize<Result<UsuarioDto>>(
                serializer.Serialize(usuario.Data));

            Assert.AreEqual(true, resultado.Success);
        }

        /// <summary>
        /// The iniciar sesion no exitoso.
        /// </summary>
        [TestMethod]
        public void IniciarSesionNoExitoso()
        {
            var usuario = this.usuarioController.IniciarSesion("asldk", "asdf");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result<UsuarioDto> resultado = serializer.Deserialize<Result<UsuarioDto>>(
                serializer.Serialize(usuario.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The iniciar sesion error no exitoso.
        /// </summary>
        [TestMethod]
        public void IniciarSesionErrorNoExitoso()
        {
            var usuario = this.usuarioController.IniciarSesion(null, "asdf");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result<UsuarioDto> resultado = serializer.Deserialize<Result<UsuarioDto>>(
                serializer.Serialize(usuario.Data));

            Assert.AreEqual(false, resultado.Success);
        }

        /// <summary>
        /// The obtener usuario.
        /// </summary>
        [TestMethod]
        public void ObtenerUsuario()
        {
            var usuario = this.usuarioController.ObtenerUsuario(1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result<UsuarioDto> resultado = serializer.Deserialize<Result<UsuarioDto>>(
                serializer.Serialize(usuario.Data));

            Assert.AreEqual(true, resultado.Success);
        }
    }
}