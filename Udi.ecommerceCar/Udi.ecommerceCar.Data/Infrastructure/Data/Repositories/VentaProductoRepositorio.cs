// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VentaProductoRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The venta producto repositorio.
    /// </summary>
    internal class VentaProductoRepositorio : EFRepositorio<VentaProducto>
    {
        /// <summary>
        /// The cambiar estado venta producto.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <param name="nuevoEstado">
        /// The nuevo estado.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            try
            {
                VentaProducto ventaProducto = this.Get(ventaProductoId);
                ventaProducto.Estado = nuevoEstado;

                this.Update(ventaProducto);
                this.SaveChanges();

                VentaProductoDto ventaProductoDto = new VentaProductoDto();
                ventaProductoDto.VentaId = ventaProducto.VentaID;
                ventaProductoDto.Monto = ventaProducto.Monto;
                ventaProductoDto.Fecha = ventaProducto.Fecha;
                ventaProductoDto.Hora = ventaProducto.Hora;
                ventaProductoDto.UsuarioId = ventaProducto.UsuarioID;
                ventaProductoDto.Estado = ventaProducto.Estado;
                ventaProductoDto.EstadoString = ((VentaEstado)ventaProducto.Estado).ToString();

                return Utilidades.ObtenerSelectVentaProductoEstado(ventaProductoDto);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// The cambiar monto venta producto.
        /// </summary>
        /// <param name="ventaProductoDto">
        /// The venta producto dto.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CambiarMontoVentaProducto(VentaProductoDto ventaProductoDto)
        {
            try
            {
                VentaProducto ventaProducto = this.Get(ventaProductoDto.VentaId);
                ventaProducto.Monto = ventaProductoDto.Monto;

                this.Update(ventaProducto);
                this.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Metodo para GuardarVentaProducto

        /// <summary>
        /// The guardar venta producto.
        /// </summary>
        /// <param name="ventaProductoDto">
        /// The venta producto dto.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GuardarVentaProducto(VentaProductoDto ventaProductoDto)
        {
            // Me da el idUsuario
            // Uso eso para crear un VentaProducto
            VentaProducto ventaProducto = new VentaProducto();
            ventaProducto.Monto = 0;
            ventaProducto.Fecha = DateTime.Now;
            ventaProducto.Hora = DateTime.Now.TimeOfDay;
            ventaProducto.UsuarioID = ventaProductoDto.UsuarioId;
            ventaProducto.Estado = ventaProductoDto.Estado;

            // Guardar VentaProducto
            this.Add(ventaProducto);
            this.SaveChanges();

            // Devuelvo la pk
            return ventaProducto.VentaID;
        }

        /// <summary>
        /// The obtener venta producto.
        /// </summary>
        /// <param name="ventaProductoDto">
        /// The venta producto dto.
        /// </param>
        /// <returns>
        /// The <see cref="VentaProductoDto"/>.
        /// </returns>
        public VentaProductoDto ObtenerVentaProducto(VentaProductoDto ventaProductoDto)
        {
            try
            {
                return
                    this.BuildQuery()
                        .Where(x => x.VentaID == ventaProductoDto.VentaId)
                        .Select(
                            ventaProducto =>
                            new VentaProductoDto()
                                {
                                    VentaId = ventaProducto.VentaID, 
                                    Monto = ventaProducto.Monto, 
                                    Fecha = ventaProducto.Fecha, 
                                    Hora = ventaProducto.Hora, 
                                    UsuarioId = ventaProducto.UsuarioID, 
                                    Estado = ventaProducto.Estado,
                                    EstadoString = ((VentaEstado)ventaProducto.Estado).ToString()
                                })
                        .First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// The obtener ventas productos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VentaProductoDto> ObtenerVentasProductosTodos()
        {
            return
                this.BuildQuery()
                    .Where(
                        x =>
                        x.Estado != (int)VentaEstado.CanceladoPorAdministrador
                        && x.Estado != (int)VentaEstado.CanceladoPorCliente)
                    .Select(
                        ventaProducto =>
                        new VentaProductoDto()
                            {
                                VentaId = ventaProducto.VentaID, 
                                Monto = ventaProducto.Monto, 
                                Fecha = ventaProducto.Fecha, 
                                Hora = ventaProducto.Hora, 
                                UsuarioId = ventaProducto.UsuarioID, 
                                Usuario =
                                    ventaProducto.Usuario.Nombre + " " + ventaProducto.Usuario.Apellido, 
                                Estado = ventaProducto.Estado, 
                                EstadoString = ((VentaEstado)ventaProducto.Estado).ToString()
                            })
                    .ToList();
        }

        public List<VentaProductoDto> ObtenerVentasProductosUsuario(int pk)
        {
            return
                this.BuildQuery()
                    .Where(
                        x =>
                        x.UsuarioID == pk
                        && x.Estado != (int)VentaEstado.CanceladoPorAdministrador
                        && x.Estado != (int)VentaEstado.CanceladoPorCliente)
                    .Select(
                        ventaProducto =>
                        new VentaProductoDto()
                        {
                            VentaId = ventaProducto.VentaID,
                            Monto = ventaProducto.Monto,
                            Fecha = ventaProducto.Fecha,
                            Hora = ventaProducto.Hora,
                            UsuarioId = ventaProducto.UsuarioID,
                            Usuario =
                                    ventaProducto.Usuario.Nombre + " " + ventaProducto.Usuario.Apellido,
                            Estado = ventaProducto.Estado,
                            EstadoString = ((VentaEstado)ventaProducto.Estado).ToString()
                        })
                    .ToList();
        }
    }
}