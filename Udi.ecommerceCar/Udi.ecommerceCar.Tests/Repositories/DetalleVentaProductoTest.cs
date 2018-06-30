// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetalleVentaProductoTest.cs" company="MC Autoventas">
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

    /// <summary>
    /// Descripción resumida de DetalleVentaProductoTest
    /// </summary>
    [TestClass]
    public class DetalleVentaProductoTest
    {
        /// <summary>
        /// The detalle venta producto controller.
        /// </summary>
        private readonly DetalleVentaProductoController detalleVentaProductoController =
            new DetalleVentaProductoController();

        /// <summary>
        /// The id venta existente.
        /// </summary>
        private readonly int idVentaExistente = 20;

        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        /// <summary>
        /// The obtener detalles ventas productos todos existe test.
        /// </summary>
        [TestMethod]
        public void ObtenerDetallesVentasProductosTodosExisteTest()
        {
            var productos =
                this.detalleVentaProductoController.ObtenerDetallesVentasProductosTodos(this.idVentaExistente);
            Result<List<DetalleVentaProductoDto>> resultado =
                this.serializer.Deserialize<Result<List<DetalleVentaProductoDto>>>(
                    this.serializer.Serialize(productos.Data));

            Assert.AreEqual(true, resultado.Success);
            Assert.AreEqual("Dunlop SP Sport Maxx", resultado.Data[0].Producto);
            Assert.AreEqual(1, resultado.Data.Count);
        }
    }
}