using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Udi.ecommerceCar.API.Controllers
{
    public class ParametroApi<T>
    {

        public T DatoG { get; set; }
        public string DatoStr { get; set; }
        public long UserId { get; set; }
    }
}