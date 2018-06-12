using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    class VentaProductoRepositorio : EFRepositorio<VentaProducto>
    {
        // Metodo para GuardarVentaProducto

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

        public bool CambiarMontoVentaProducto(VentaProductoDto ventaProductoDto)
        {
            try
            {
                VentaProducto ventaProducto = this.Get(ventaProductoDto.VentaId);
                ventaProducto.Monto = ventaProductoDto.Monto;

                Update(ventaProducto);
                this.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


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
                                Estado = ventaProducto.Estado
                            })
                        .First();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<VentaProductoDto> ObtenerVentasProductosTodos()
        {
            return
                this.BuildQuery()
                    .Where(x => x.Estado != (int)VentaEstado.CanceladoPorAdministrador &&
                                x.Estado != (int)VentaEstado.CanceladoPorCliente)
                    .Select(
                        ventaProducto =>
                        new VentaProductoDto()
                        {
                            VentaId = ventaProducto.VentaID,
                            Monto = ventaProducto.Monto,
                            Fecha = ventaProducto.Fecha,
                            Hora = ventaProducto.Hora,
                            UsuarioId = ventaProducto.UsuarioID,
                            Usuario = ventaProducto.Usuario.Nombre + " " + ventaProducto.Usuario.Apellido,
                            Estado = ventaProducto.Estado,
                            EstadoString = ((VentaEstado)ventaProducto.Estado).ToString()
                        })
                    .ToList();
        }

        public string CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            try
            {
                VentaProducto ventaProducto = Get(ventaProductoId);
                ventaProducto.Estado = nuevoEstado;

                Update(ventaProducto);
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
                return "";
            }
        }
    }
}
