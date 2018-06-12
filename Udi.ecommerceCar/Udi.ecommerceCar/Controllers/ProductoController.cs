// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The producto controller.
    /// </summary>
    public class ProductoController : Controller
    {
        /// <summary>
        /// The producto servicio.
        /// </summary>
        private readonly ProductoServicio productoServicio = new ProductoServicio();

        /// <summary>
        /// The detalle.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Detalle(int id)
        {
            ProductoDto producto = this.productoServicio.ObtenerProducto(id);
            return producto != null ? this.View(producto) : this.View();
        }

        /// <summary>
        /// The guardar producto.
        /// </summary>
        /// <param name="productoString">
        /// The producto String.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult GuardarProducto(string productoString)
        {
            try
            {
                ProductoDto productoDto = ComunServicio.ObtenerDtoFromString<ProductoDto>(productoString);
                int id = this.productoServicio.ObtenerProductosTodos().Count;
                productoDto.ProductoId = id;

                int pk = this.productoServicio.GuardarProducto(productoDto);

                return new JsonResult { Data = new { Success = true, Data = pk } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The obtener producto.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProducto(int pk)
        {
            var data = this.productoServicio.ObtenerProducto(pk);
            return new JsonResult { Data = new { Success = true, Data = data } };
        }

        /// <summary>
        /// The obtener productos.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProductos(int? page, int? size)
        {
            var data = this.productoServicio.ObtenerProductos(page, size);
            return new JsonResult { Data = new { Success = true, Data = data } };
        }

        /// <summary>
        /// The obtener productos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProductosTodos()
        {
            var data = this.productoServicio.ObtenerProductosTodos();
            return new JsonResult { Data = new { Success = true, Data = data } };
        }

        /// <summary>
        /// The marcar principal producto.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult MarcarPrincipalProducto(int id)
        {
            try
            {
                var data = this.productoServicio.MarcarPrincipalProducto(id);
                
                string mensaje = data
                                     ? "Producto marcado como principal correctamente"
                                     : "Producto desmarcado como principal correctamente";

                return new JsonResult { Data = new { Success = true, Mensaje = mensaje } };
            }
            catch (Exception)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = "Error al querer marcar/desmarcar el producto" } };
            }
        }

        /// <summary>
        /// The obtener productos principales.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProductosPrincipales()
        {
            var data = this.productoServicio.ObtenerProductosPrincipales();
            return new JsonResult { Data = new { Success = true, Data = data } };
        }

        /// <summary>
        /// The solicitar pedido producto.
        /// </summary>
        /// <param name="idUsuario">
        /// The id usuario.
        /// </param>
        /// <param name="listaProductosString">
        /// The lista productos string.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult SolicitarPedidoProducto(int idUsuario, string listaProductosString)
        {
            try
            {
                List<ProductoDto> listaProductosDto = ComunServicio.ObtenerDtoFromString<List<ProductoDto>>(listaProductosString);
                var data = this.productoServicio.SolicitarPedidoProducto(idUsuario, listaProductosDto);
                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The modificar producto.
        /// </summary>
        /// <param name="productoModificadoDtoString">
        /// The producto modificado dto string.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ModificarProducto(string productoModificadoDtoString)
        {
            try
            {
                ProductoDto productoDto = ComunServicio.ObtenerDtoFromString<ProductoDto>(productoModificadoDtoString);
                bool modificado = this.productoServicio.ModificarProducto(productoDto);

                return new JsonResult { Data = new { Success = true, Data = modificado } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The eliminar producto.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult EliminarProducto(int pk)
        {
            try
            {
                bool eliminado = this.productoServicio.EliminarProducto(pk);
                return new JsonResult { Data = new { Success = true, Data = eliminado } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}