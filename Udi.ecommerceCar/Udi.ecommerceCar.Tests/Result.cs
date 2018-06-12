using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Udi.ecommerceCar.Tests
{
    class Result<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the mensaje.
        /// </summary>
        public string Mensaje { get; set; }
        
        public T Data { get; set; }

        //public List<T> ListData { get; set; } 
    }
}
