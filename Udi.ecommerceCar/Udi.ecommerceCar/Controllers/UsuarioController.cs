using System;
using System.Web.Mvc;
using Udi.ecommerceCar.Data.Domain.Services;

namespace Udi.ecommerceCar.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        //// GET: Usuario
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public JsonResult ObtenerUsuario(int pk)
        {
            try
            {
                var data = _usuarioServicio.ObtenerUsuario(pk);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult IniciarSesion(string username, string password)
        {
            try
            {
                var data = _usuarioServicio.IniciarSesion(username, password);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                Session["usuario"] = data;

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
        
    }
}