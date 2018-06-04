// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The servicio dto.
    /// </summary>
    public class ServicioDto
    {
        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the descripcion corta.
        /// </summary>
        public string DescripcionCorta { get; set; }

        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        public bool? Estado { get; set; }

        /// <summary>
        /// Gets or sets the imagen id.
        /// </summary>
        public int? ImagenId { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        public decimal? Precio { get; set; }

        /// <summary>
        /// Gets or sets the puntuacion.
        /// </summary>
        public int? Puntuacion { get; set; }

        /// <summary>
        /// Gets or sets the servicio id.
        /// </summary>
        public int ServicioId { get; set; }

        /// <summary>
        /// Gets or sets the tipo servicio.
        /// </summary>
        public string TipoServicio { get; set; }

        /// <summary>
        /// Gets or sets the tipo servicio id.
        /// </summary>
        public int TipoServicioId { get; set; }

        /// <summary>
        /// Gets or sets the url amigable.
        /// </summary>
        public string UrlAmigable { get; set; }

        /// <summary>
        /// Gets or sets the visible main.
        /// </summary>
        public bool? VisibleMain { get; set; }
    }
}