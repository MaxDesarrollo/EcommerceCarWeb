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
        public int ProductoID { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto.
        /// </summary>
        public string TipoProducto { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto id.
        /// </summary>
        public int? TipoProductoID { get; set; }
    }
}