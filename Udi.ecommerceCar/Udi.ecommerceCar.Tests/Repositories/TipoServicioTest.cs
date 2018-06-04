// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoServicioTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// Descripción resumida de TipoServicioTest
    /// </summary>
    [TestClass]
    public class TipoServicioTest
    {
        /// <summary>
        /// The tipo servicio servicio.
        /// </summary>
        private readonly TipoServicioServicio tipoServicioServicio = new TipoServicioServicio();

        /// <summary>
        /// The obtener tipos servicios todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerTiposServiciosTodosExisteTest()
        {
            var tipoServicios = this.tipoServicioServicio.ObtenerTiposServiciosTodos();

            Assert.IsNotNull(tipoServicios);
        }
    }
}