// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComunServicioTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Services
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The comun servicio test.
    /// </summary>
    [TestClass]
    public class ComunServicioTest
    {
        /// <summary>
        /// The obtener producto nulo no exitoso.
        /// </summary>
        [TestMethod]
        public void ObtenerProductoNuloNoExitoso()
        {
            Exception exception = null;

            try
            {
                var usuario = ComunServicio.ObtenerDtoFromString<ProductoDto>(null);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
        }
    }
}