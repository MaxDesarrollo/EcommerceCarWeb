using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public Usuario ObtenerUsuario(int pk)
        {
            return _usuarioRepositorio.ObtenerUsuario(pk);
        }

        public UsuarioDto IniciarSesion(string username, string password)
        {
            return _usuarioRepositorio.IniciarSesion(username, password);
        }
    }
}
