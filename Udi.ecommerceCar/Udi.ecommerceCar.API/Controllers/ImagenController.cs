using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using Udi.ecommerceCar.API.Models;
using Udi.ecommerceCar.Data;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Domain.Services;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;


namespace Udi.ecommerceCar.Api.Controllers
{
    public class ImagenController : ApiController
    {


        private readonly ImagenServicio imagenServicio = new ImagenServicio();

        [System.Web.Http.Route("api/image/get")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult ObtenerImagen(int id)
        {
            try
            {
             
                var Resultado = imagenServicio.ObtenerImagen(id);

          

                return Ok(RespuestaApi<ImagenDto>.createRespuestaSuccess(Resultado));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.Message));
                throw;
            }

        }

        [System.Web.Http.Route("api/image/getUrl")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetImagen(int id)
        {
           

                var urlImagen = imagenServicio.ObtenerUrlImagen(id);

                Byte[] b = File.ReadAllBytes(@urlImagen);



                MemoryStream ms = new MemoryStream(b);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return response;



        }


    }




    }

