using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udi.ecommerceCar.Data.Domain.Services;

namespace Udi.ecommerceCar.Controllers
{
    public class DetalleVentaProductoController : Controller
    {
        //// GET: DetalleVentaProducto
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly DetalleVentaProductoServicio detalleVentaProductoServicio = new DetalleVentaProductoServicio();

        public JsonResult ObtenerDetallesVentasProductosTodos(int VentaProductoId)
        {
            try
            {
                var data = this.detalleVentaProductoServicio.ObtenerDetallesVentasProductosTodos(VentaProductoId);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
        
    }
}