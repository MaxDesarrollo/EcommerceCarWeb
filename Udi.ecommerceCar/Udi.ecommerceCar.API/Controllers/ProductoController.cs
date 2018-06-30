using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udi.ecommerceCar.API.Controllers;
using Udi.ecommerceCar.API.Models;
using Udi.ecommerceCar.Data;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Domain.Services;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Api.Controllers
{
    public class ProductoController : ApiController
    {

        private readonly ProductoServicio productoServicio = new ProductoServicio();

        [Route("api/product/get")]
        [HttpPost]
        public IHttpActionResult Sincronizar([FromBody]ParametroApi<List<string>> Parametros)
        {
            try
            {
                string fecha = Parametros.DatoStr;

                DateTime date = DateTime.ParseExact("1990-01-01T00:00:00", "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
                //bool PrimeraVez = true;
                if (!string.IsNullOrEmpty(fecha) && !fecha.Equals("1990-01-01T00:00:00"))
                {
                    date = DateTime.ParseExact(fecha, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
                    //PrimeraVez = false;
                }


                

                var Resultado = productoServicio.ObtenerProductosTodos();

                return Ok(RespuestaApi<List<ProductoDto>>.createRespuestaSuccess(Resultado));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.Message));
                throw;
            }
            
        }



        [Route("api/product/obtener")]
        [HttpPost]
        public IHttpActionResult ObtenerPorId([FromBody]ParametroApi<int> Parametros)
        {
            try
            {
                int ProductoId = Parametros.DatoG;

                

                var Resultado = productoServicio.ObtenerProducto(ProductoId);

                return Ok(RespuestaApi<ProductoDto>.createRespuestaSuccess(Resultado));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.Message));
                throw;
            }

        }

    }
}
