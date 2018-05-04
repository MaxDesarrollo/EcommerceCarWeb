using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udi.ecommerceCar.Data.Domain.Services;

namespace Udi.ecommerceCar.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServicioServicio servicioServicio = new ServicioServicio();

        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GuardarServicio(string , string descripcion, int cantidad, int tipoProductoId)
        //{
        //    try
        //    {
        //        //Producto prod = ComunServicio.ObtenerDtoFromString<Producto>(producto);
        //        int id = productoServicio.ObtenerProductos().Count;
        //        ProductoDto prod = new ProductoDto()
        //        {
        //            ProductoID = id + 1,
        //            Nombre = nombre,
        //            Descripcion = descripcion,
        //            Cantidad = cantidad,
        //            TipoProductoID = tipoProductoId
        //        };
        //        int pk = productoServicio.GuardarProducto(prod);

        //        return new JsonResult { Data = new { Success = true, Data = pk } };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
        //    }
        //}

        public JsonResult ObtenerServiciosTodos()
        {
            try
            {
                var data = servicioServicio.ObtenerServiciosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult ObtenerServicios(int page, int size)
        {
            try
            {
                var data = servicioServicio.ObtenerServicios(page, size);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}