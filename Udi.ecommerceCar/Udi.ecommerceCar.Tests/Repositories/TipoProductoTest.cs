// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoProductoTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The tipo producto test.
    /// </summary>
    [TestClass]
    public class TipoProductoTest
    {
        /// <summary>
        /// The tipo producto servicio.
        /// </summary>
        private readonly TipoProductoServicio tipoProductoServicio = new TipoProductoServicio();

        /// <summary>
        /// The obtener tipos productos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerTiposProductosTodosExisteTest()
        {
            var tipoProductos = this.tipoProductoServicio.ObtenerTiposProductosTodos();

            Assert.IsNotNull(tipoProductos);
        }
    }
}