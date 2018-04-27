using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    class UsuarioDto
    {
        private int UsuarioID { get; set; }

        private string Nombre { get; set; }
        private string Apellido { get; set; }

        private string Username { get; set; }

        private string Password { get; set; }


    }
}
