﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    public class ServicioDto
    {
        public int ServicioID { get; set; }

        ////////////CAMBIAAAAAR
        public string Precio { get; set; }
        public string Estado { get; set; }


        public int TipoServicioID { get; set; }
        public string TipoServicio { get; set; }
    }
}