// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Security.Policy;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The usuario repositorio.
    /// </summary>
    internal class UsuarioRepositorio : EFRepositorio<Usuario>
    {
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
            try
            {
                // Usuario usuario = Get(pk);
                // return usuario;
                return
                    this.BuildQuery()
                        .Select(
                            usuario =>
                            new UsuarioDto()
                                {
                                    UsuarioId = usuario.UsuarioID, 
                                    Nombre = usuario.Nombre, 
                                    Apellido = usuario.Apellido, 
                                    Username = usuario.Username, 
                                    Password = usuario.Password
                                })
                        .First(x => x.Username == username && x.Password == password);
            }
            catch (ExcepcionComercio)
            {
                return null;
            }
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
            Usuario usuario = this.Get(pk);
            UsuarioDto usuarioDto = 
                new UsuarioDto()
                    {
                        UsuarioId = usuario.UsuarioID,
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Username = usuario.Username,
                        Password = usuario.Password
                    };

            return usuarioDto;
        }

        /// <summary>
        /// The registrar usuario.
        /// </summary>
        /// <param name="usuarioDto">
        /// The usuario Dto.
        /// </param>
        /// <returns>
        /// The <see cref="UsuarioDto"/>.
        /// </returns>
        public UsuarioDto RegistrarUsuario(UsuarioDto usuarioDto)
        {
            Usuario newUsuario = new Usuario()
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Username = usuarioDto.Username,
                Password = usuarioDto.Password
            };

            this.Add(newUsuario);
            this.SaveChanges();

            return usuarioDto;
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
            try
            {
                UsuarioDto usuarioDto =
                this.BuildQuery()
                    .Where(x => x.Username == username)
                    .Select(
                        usuario =>
                        new UsuarioDto()
                        {
                            UsuarioId = usuario.UsuarioID,
                            Nombre = usuario.Nombre,
                            Apellido = usuario.Apellido,
                            Username = usuario.Username,
                            Password = usuario.Password
                        })
                    .First();

                return usuarioDto;
            }
            catch (ExcepcionComercio)
            {
                return null;
            }
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
            Usuario usuario = this.Get(pk);
            return usuario.Username == "Raiden";
        }
    }
}