﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The usuario controller.
    /// </summary>
    public class UsuarioController : Controller
    {
        /// <summary>
        /// The _usuario servicio.
        /// </summary>
        private readonly UsuarioServicio usuarioServicio = new UsuarioServicio();

        //// GET: Usuario
        // public ActionResult Index()
        // {
        // return View();
        // }

        /// <summary>
        /// The carrito.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Carrito()
        {
            return this.View();
        }

        /// <summary>
        /// The mis pedidos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>ActionResult</cref>
        ///     </see>
        ///     .
        /// </returns>
        public ActionResult MisPedidos()
        {
            return this.View();
        }

        /// <summary>
        /// The registro.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Registro()
        {
            return this.View();
        }

        /// <summary>
        /// The iniciar sesion.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult IniciarSesion(string username, string password)
        {
            try
            {
                var data = this.usuarioServicio.IniciarSesion(username, password);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                // Session["usuario"] = data;
                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The obtener usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerUsuario(int pk)
        {
            try
            {
                var data = this.usuarioServicio.ObtenerUsuario(pk);

                return data == null ? new JsonResult { Data = new { Success = false } } : new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The registrar usuario.
        /// </summary>
        /// <param name="usuarioString">
        /// The usuario String.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult RegistrarUsuario(string usuarioString)
        {
            try
            {
                UsuarioDto usuarioDto = ComunServicio.ObtenerDtoFromString<UsuarioDto>(usuarioString);
                var data = this.usuarioServicio.RegistrarUsuario(usuarioDto);

                if (data != null)
                {
                    return new JsonResult { Data = new { Success = true, Data = data } };
                }
                
                return new JsonResult { Data = new { Success = false, Mensaje = "El Usuario ya existe. Por favor escoger otro nombre de usuario." } };
            }
            catch (ExcepcionComercio)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = "error" } };
            }
        }

        /// <summary>
        /// The autorizar usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult AutorizarUsuario(int pk)
        {
            try
            {
                // UsuarioDto usuarioDto = ComunServicio.ObtenerDtoFromString<UsuarioDto>(usuarioString);
                var autorizado = this.usuarioServicio.AutorizarUsuario(pk);

                return new JsonResult { Data = new { Success = true, Autorizado = autorizado } };
            }
            catch (ExcepcionComercio)
            {
                return new JsonResult { Data = new { Success = false, Autorizado = false } };
            }
        }

        /// <summary>
        /// The obtener ventas productos usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVentasProductosUsuario(int pk)
        {
            try
            {
                VentaProductoServicio ventaProductoServicio = new VentaProductoServicio();
                var data = ventaProductoServicio.ObtenerVentasProductosUsuario(pk);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}