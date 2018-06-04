// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The producto dto.
    /// </summary>
    public class ProductoDto
    {
        /// <summary>
        /// Gets or sets the cantidad.
        /// </summary>
        public int? Cantidad { get; set; }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the descripcion corta.
        /// </summary>
        public string DescripcionCorta { get; set; }

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
        /// Gets or sets the producto id.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Gets or sets the puntuacion.
        /// </summary>
        public int? Puntuacion { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto.
        /// </summary>
        public string TipoProducto { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto id.
        /// </summary>
        public int? TipoProductoId { get; set; }

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