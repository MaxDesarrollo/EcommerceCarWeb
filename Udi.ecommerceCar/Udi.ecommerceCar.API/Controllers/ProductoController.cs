using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udi.ecommerceCar.API.Models;

namespace Udi.ecommerceCar.API.Controllers
{
    public class ProductoController : ApiController
    {

        [Route("api/product/get")]
        [HttpPost]

        public IHttpActionResult Sincronizar([FromBody] ParametroApi<List<string>> Parametros)
        {
            try
            {
                string Fecha = Parametros.DatoStr;
                long idUsuario = Parametros.UserId;

                DateTime date = DateTime.ParseExact("1990-01-01T00:00:00", "yyyy-MM-dd'T'HH:mm:ss",
                    CultureInfo.InvariantCulture);

                bool primeraVez = true;
                bool userRegister = false;

                if (!string.IsNullOrEmpty(Fecha) && !Fecha.Equals("1990-01-01T00:00:00"))
                {

                    date = DateTime.ParseExact(Fecha, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
                    primeraVez = false;
                }

                if (idUsuario == 0)
                {
                    userRegister = false;
                }
                else
                {
                    userRegister = true;
                }



                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.Message));
            }


        }

    }
}
