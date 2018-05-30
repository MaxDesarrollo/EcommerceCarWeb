using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class ImagenRepositorio : EFRepositorio<Imagen>
    {


        public ImagenDto ObtenerImagen(int pk)
        {
            Imagen imagen = Get(pk);
            return new ImagenDto()
            {

                ImagenID = imagen.ImagenID,
                UrlImagen = imagen.UrlImagen

            };

        }


        public string GetUrlImagen(int pk)
        {

            Imagen imagen = Get(pk);

            new ImagenDto()
            {

                UrlImagen = imagen.UrlImagen
            };


            return imagen.UrlImagen;


        }
    }
}
