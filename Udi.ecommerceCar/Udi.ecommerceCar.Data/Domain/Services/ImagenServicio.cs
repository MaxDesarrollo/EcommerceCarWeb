using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class ImagenServicio
    {
        private readonly ImagenRepositorio imagenRepositorio;

        public ImagenServicio()
        {
            this.imagenRepositorio = new ImagenRepositorio();

        }

        public ImagenDto ObtenerImagen(int pk)
        {
            return imagenRepositorio.ObtenerImagen(pk);
        }

        public string ObtenerUrlImagen(int pk)
        {

            return imagenRepositorio.GetUrlImagen(pk);
        }
    }
}
