using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udi.ecommerceCar.Controllers
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    public class VentaProductoController : Controller
    {
        private readonly VentaProductoServicio ventaProductoServicio = new VentaProductoServicio();

        //// GET: VentaProducto
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // Para que desde el dashboard pueda llamar la lista de los ventaProducto
        public JsonResult ObtenerVentasProductosTodos()
        {
            try
            {
                var data = this.ventaProductoServicio.ObtenerVentasProductosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            try
            {
                string nuevoEstadoSelect = this.ventaProductoServicio.CambiarEstadoVentaProducto(ventaProductoId, nuevoEstado);

                return new JsonResult { Data = new { Success = true, Data = nuevoEstadoSelect } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}