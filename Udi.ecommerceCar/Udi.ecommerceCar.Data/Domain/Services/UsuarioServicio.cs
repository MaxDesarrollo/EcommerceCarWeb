// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The usuario servicio.
    /// </summary>
    public class UsuarioServicio
    {
        /// <summary>
        /// The _usuario repositorio.
        /// </summary>
        private readonly UsuarioRepositorio usuarioRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioServicio"/> class.
        /// </summary>
        public UsuarioServicio()
        {
            this.usuarioRepositorio = new UsuarioRepositorio();
        }

        /// <summary>
        /// The iniciar sesion.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="UsuarioDto"/>.
        /// </returns>
        public UsuarioDto IniciarSesion(string username, string password)
        {
            return this.usuarioRepositorio.IniciarSesion(username, password);
        }

        /// <summary>
        /// The obtener usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="Usuario"/>.
        /// </returns>
        public UsuarioDto ObtenerUsuario(int pk)
        {
            return this.usuarioRepositorio.ObtenerUsuario(pk);
        }

        /// <summary>
        /// The obtener usuario por username.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="UsuarioDto"/>.
        /// </returns>
        public UsuarioDto ObtenerUsuarioPorUsername(string username)
        {
            return this.usuarioRepositorio.ObtenerUsuarioPorUsername(username);
        }

        /// <summary>
        /// The registrar usuario.
        /// </summary>
        /// <param name="usuarioDto">
        /// The usuario dto.
        /// </param>
        /// <returns>
        /// The <see cref="UsuarioDto"/>.
        /// </returns>
        public UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto)
        {
            UsuarioDto usuario = this.ObtenerUsuarioPorUsername(usuarioDto.Username);
            return usuario == null ? this.usuarioRepositorio.RegistrarUsuario(usuarioDto) : null;
        }

        /// <summary>
        /// The autorizar usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AutorizarUsuario(int pk)
        {
            return this.usuarioRepositorio.AutorizarUsuario(pk);
        }
    }
}